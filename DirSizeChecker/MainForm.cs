//=============================================================================
// システム名称　　　： ディレクトリサイズチェッカー
// サブシステム名　　： 
// 機能名　　　　　　： 
// ソースファイル名　： MainForm.cs
//-----------------------------------------------------------------------------
// 機能概要　　　　　： ディレクトリサイズチェッカーのメイン画面
//-----------------------------------------------------------------------------
// 改訂履歴    区分  改訂番号  社名)担当   内容
// 2014.06.02  新規  ----      CS)土田
//=============================================================================

using System;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace DirSizeChecker
{
	/// <summary>
	/// メインフォーム
	/// </summary>
	public partial class MainForm : Form
    {
		/// <summary>
		/// LOG4NETのロガー
		/// </summary>
		private static log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// 解析モジュール
		/// </summary>
		private DirectoryData dataModel = new DirectoryData();

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        private void Init()
        {
            Logger.Debug("Init() 呼び出し");

            try
            {
				//2014/05/30:削除:>>>>>ここから
				//if (this.dataModel != null)
				//{
					//初回でなければ何もせず終了
					//Logger.Debug("すでに初期化が行われているため終了");
					//return;
				//}
				
				//モデルクラスのインスタンスを生成
                //this.dataModel = new DirectoryData();
				//モデル初期化
                //this.dataModel.Init();

                //モデルからデータビューを取得
				//DataView dataView = this.dataModel.TableView;

				//if (dataView != null)
				//{

					//並び替え：ファイルサイズの大きい順
					//※ここでの変更は元のTableViewプロパティにも作用する
					//dataView.Sort = String.Format(Properties.Settings.Default.DirSort, DirectoryData.COLUMN_SIZE);

					//グラフのデータソースに設定
					//※この時点ではバインドはされていない
					//this.volumeGraph.DataSource = dataView;
					//this.volumeGraph.Series[GRAPH_SERIES].XValueMember = DirectoryData.COLUMN_NAME;
					//this.volumeGraph.Series[GRAPH_SERIES].YValueMembers = DirectoryData.COLUMN_SIZE;

					//2014/05/29:削除:>>>>>ここから
					//ディレクトリ一覧のデータソースに設定
					//this.directoryList.DataSource = dataView;
					//2014/05/29:削除:<<<<<ここまで
				//}
				//2014/05/30:削除:<<<<<ここまで

				//2014/05/30:追加:>>>>>ここから
				//モデルが参照するテーブルを設定
				this.dataModel.Table = this.directoryDataSet.Directories;

				//ファイルサイズが入る列の名前
				string columnName = this.directoryDataSet.Directories.SizeColumn.ColumnName;
				//並び替え：サイズの大きい順
				this.directoriesBindingSource.Sort = String.Format(Properties.Settings.Default.DirSort, columnName);
				//2014/05/30:追加:<<<<<ここまで
            }
            catch (Exception ex)
            {
                Logger.WarnFormat("Init 処理中に例外が発生 (理由={0})", ex);
                return;
            }

            Logger.Debug("Init 成功");
        }

        /// <summary>
        /// ディレクトリ解析を行い、すべてのビューを更新
        /// </summary>
        /// <param name="path">計算対象ディレクトリ。nullまたは空文字の場合、処理を行わずに終了する。</param>
        private void UpdateAll(string path)
        {
            Logger.DebugFormat("UpdateAll(\"{0}\") 呼び出し", path);

            try
            {
                bool isEmpty = String.IsNullOrEmpty(path);

                //引数チェック
                if (isEmpty)
				{
					//引数が無効なら終了
                    Logger.Debug("引数 path が null または空文字のため終了");
                    return;
                }

                //読み込み処理中であることをラベルで知らせる
                this.labelFullPath.Text = Properties.Resources.MsgLoading;

                //グラフを非表示
                this.volumeGraph.Hide();

                //ディレクトリ一覧のデータバインドを解除
				//※切っておかないとビューが壊れる
                this.directoryList.DataSource = null;

                //すべてのボタンを無効化
                this.buttonMoveUp.Enabled = false;
                this.buttonReload.Enabled = false;
                this.buttonExecute.Enabled = false;

                //パス文字列を引数として、非同期処理開始
                this.bgReader.RunWorkerAsync(path);
            }
            catch (Exception ex)
            {
                //ボタンを有効化
                this.buttonMoveUp.Enabled = true;
                this.buttonReload.Enabled = true;
                this.buttonExecute.Enabled = true;

                Logger.WarnFormat("UpdateAll 処理中に例外が発生 (理由={0})", ex);
                return;
            }

            Logger.Debug("UpdateAll 成功");
        }

        /// <summary>
        /// [ひとつ上へ]ボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMoveUp_Click(object sender, EventArgs e)
        {
			Logger.Info("ButtonMoveUp クリック");
			Logger.Debug("ButtonMoveUp_Click() 呼び出し");

            try
            {
                //移動先を親ディレクトリとする
                string newPath = this.dataModel.GetParentDirectory();
				bool isEmpty = String.IsNullOrEmpty(newPath);

				if (isEmpty)
                {
                    //パスが空ならダイアログを出して終了
                    MessageBox.Show(Properties.Resources.MsgNoParent);

                    Logger.Debug("GetParentDirectory() が空文字を返したため終了");
                    return;
                }

                //更新
                this.UpdateAll(newPath);
            }
            catch (Exception ex)
            {
                Logger.WarnFormat("ButtonMoveUp_Click 処理中に例外が発生 (理由={0})", ex);
				return;
            }

			Logger.Debug("ButtonMoveUp_Click 成功");
		}

        /// <summary>
        /// [更新]ボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReload_Click(object sender, EventArgs e)
        {
			Logger.Info("ButtonReload クリック");
			Logger.Debug("ButtonReload_Click() 呼び出し");

            try
            {
                //移動先を現在のディレクトリとする
				string newPath = this.dataModel.GetCurrentDirectory();
				bool isEmpty = String.IsNullOrEmpty(newPath);

				if (isEmpty)
				{
					//パスが空ならダイアログを出して終了
					MessageBox.Show(Properties.Resources.MsgNoPath);

					Logger.Debug("GetCurrentDirectory() が空文字を返したため終了");
					return;
				}

                //更新
                this.UpdateAll(newPath);
            }
            catch (Exception ex)
            {
                Logger.WarnFormat("ButtonReload_Click 処理中に例外が発生 (理由={0})", ex);
				return;
            }

			Logger.Debug("ButtonReload_Click 成功");
		}

        /// <summary>
        /// [解析実行]ボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExecute_Click(object sender, EventArgs e)
        {
            Logger.Info("ButtonExecute クリック");
			Logger.Debug("ButtonExecute_Click() 呼び出し");

            try
            {
                //リストで何も選択されていなければ終了
                if (this.directoryList.SelectedRows.Count == 0)
				{
					//ダイアログで通知
                    MessageBox.Show(Properties.Resources.MsgNoSelected);

                    Logger.Debug("directoryList にて何も選択されていないため終了");
                    return;
                }

				//選択行を取得
				//※取得に失敗したときは例外として扱う
                DataGridViewRow row = this.directoryList.SelectedRows[0];

                string dir = string.Empty;

                try
                {
                    //Nameカラムからディレクトリ名を得る
					DataGridViewCell cell = row.Cells[this.directoryDataSet.Directories.NameColumn.ColumnName];
                    dir = cell.Value as string;
                }
                catch (ArgumentException aex)
                {
                    //指定したカラムが存在しなければ終了
                    Logger.WarnFormat("カラムが存在しないため終了 (詳細={0})", aex);
                    return;
                }

                //現在のディレクトリ
                string currentPath = this.dataModel.GetCurrentDirectory();
                //選択したディレクトリと結合し、移動先を得る
                string newPath = Path.Combine(currentPath, dir);

                //表示更新
                this.UpdateAll(newPath);
            }
            catch (Exception ex)
            {
                Logger.WarnFormat("ButtonExecute_Click 処理中に例外が発生 (理由={0})", ex);
				return;
            }

			Logger.Debug("ButtonExecute_Click 成功");
		}

        /// <summary>
        /// 起動後処理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            Logger.Debug("MainForm_Load() 呼び出し");

            try
            {
                //初期化処理
                this.Init();

				//2014/05/30:変更:CS)土田 >>>>> ここから
                ////初期ディレクトリ：ユーザーのデスクトップ
                //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				//初期ディレクトリ：ユーザーのドキュメント
				string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				//2014/06/03:変更:CS)土田 <<<<< ここまで

				//表示更新
                //※呼び出し先でnullチェックするので、ここでは不要
                this.UpdateAll(path);
            }
            catch (Exception ex)
            {
                Logger.WarnFormat("MainForm_Load 処理中に例外が発生 (理由={0})", ex);
                return;
            }

            Logger.Debug("MainForm_Load 成功");
        }

        /// <summary>
        /// データエラーによる例外への処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void directoryList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null)
            {
				//例外を握りつぶして処理終了
                Logger.WarnFormat("directoryList データエラーによる例外が発生 (理由={0})", e.Exception);
            }
        }

        /// <summary>
        /// ユーザー操作でソート方法が変更された時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void directoryList_Sorted(object sender, EventArgs e)
        {
            Logger.Info("directoryList ソート順変更");

            try
            {
                //データバインドをやり直し、円グラフにも同じソート順を適用する。
                this.volumeGraph.DataBind();
            }
            catch (Exception ex)
            {
                Logger.WarnFormat("bgReader_RunWorkerCompleted 処理中に例外が発生 (理由={0})", ex);
                return;
            }
        }

        /// <summary>
        /// バックグラウンド実行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void bgReader_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //※ここでUIを操作しないこと※

            //例外処理は基本的に不要だが、ログを残すためにtry-finallyを使う
            try
            {
                Logger.Info("バックグラウンドスレッド bgReader 開始");

				//2014/05/30:削除:>>>>>ここから
                //モデルインスタンスが存在しなければキャンセル扱いで終了
                //if (this.dataModel == null)
                //{
                    //e.Cancel = true;
                   //return;
				//}
				//2014/05/30:削除:<<<<<ここまで

                string path = e.Argument as string;
				bool isEmpty = string.IsNullOrEmpty(path);

				if (isEmpty)
                {
					//パスを取得できなければキャンセル扱いで終了
					e.Cancel = true;

					Logger.Debug("パスが空だったため終了");
                    return;
                }

				//2014/05/30:変更:>>>>>ここから
                //RunWorkerCompletedに渡す結果判定用bool値
				//Nullable<bool> result = false;
                //すべてのサブフォルダを調べる
				//result = this.dataModel.ReadDirectory(path);

				//解析結果を取得
				//2014/06/03:変更:>>>>>ここから
				//bool result = this.dataModel.ReadDirectory(path);
				bool result = this.dataModel.ReadDirectory(path, this.bgReader);
				//2014/06/03:変更:<<<<<ここまで

				//2014/05/30:変更:<<<<<ここまで

				//結果をbgReader_RunWorkerCompletedに渡す
                e.Result = result;
            }
            finally
            {
                //処理が正常に完了したらログに記録
                Logger.Info("バックグラウンドスレッド bgReader 終了");
            }
        }

        /// <summary>
        /// サイズ計算完了後処理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgReader_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Logger.Debug("bgReader_RunWorkerCompleted() 呼び出し");

            try
            {
                //すべてのボタンを有効化
                this.buttonMoveUp.Enabled = true;
                this.buttonReload.Enabled = true;
                this.buttonExecute.Enabled = true;

                //パスラベルを空に
                this.labelFullPath.Text = string.Empty;

                //非同期処理内で例外が発生していたら終了
                if (e.Error != null)
                {
                    Logger.WarnFormat("bgReader_DoWork で例外が発生 (理由={0})", e.Error);
                    return;
                }

                //非同期処理が中断されていたら終了
                if (e.Cancelled)
                {
                    Logger.Debug("bgReader_DoWork が中断されたため終了");
                    return;
                }

                //計算処理の結果を取得
                //e.Errorとe.Cancelledいずれかが有効な状態でe.Resultにアクセスすると例外発生
                Nullable<bool> result = e.Result as Nullable<bool>;

                //失敗していたら終了
                if (result != true)
                {
                    Logger.Debug("解析に失敗したため終了");
                    return;
                }

                //データをバインド
                this.volumeGraph.DataBind();
                this.volumeGraph.Show();
				//2014/05/30:変更:>>>>>ここから
				//this.directoryList.DataSource = this.dataModel.TableView;
				this.directoryList.DataSource = this.directoriesBindingSource;
				//2014/05/30:変更:<<<<<ここまで
                this.directoryList.ClearSelection();

                //解析したパスをラベルに表示
                this.labelFullPath.Text = this.dataModel.GetCurrentDirectory();

				//2014/05/29:追加:>>>>>ここから
                //検出ディレクトリ数
                long found = this.dataModel.LastFound;
                //解析したディレクトリ数
                long success = this.dataModel.LastSucceeded;
                //既定のフォーマットで出力
                string msg = String.Format(Properties.Resources.MsgResult, found, success);
                //解析結果をユーザーに通知
				MessageBox.Show(msg);
				//2014/05/29:追加:<<<<<ここまで
            }
            catch (Exception ex)
            {
                Logger.WarnFormat("bgReader_RunWorkerCompleted 処理中に例外が発生 (理由={0})", ex);
                return;
            }

            Logger.Debug("bgReader_RunWorkerCompleted 成功");
        }

		/// <summary>
		///	バックグラウンド処理の進行状況通知
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bgReader_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
		{
			//※この処理はUIスレッドで行われる
			Logger.Debug("bgReader_ProgressChanged 呼び出し");

			try
			{
				//検出したフォルダ数
				long? found = e.UserState as long?;

				if (!found.HasValue)
				{
					//検出数を受け取れなかったら終了
					Logger.Debug("UserStateを取得できなかったため終了");
					return;
				}

				//進捗メッセージ
				string msg = string.Format(Properties.Resources.MsgProgress, Properties.Resources.MsgLoading, found);

				//ラベルに設定
				this.labelFullPath.Text = msg;
			}
			catch (Exception ex)
			{
				Logger.WarnFormat("bgReader_ProgressChanged 処理中に例外が発生 (理由={0})", ex);
				return;
			}

			Logger.Debug("bgReader_ProgressChanged 成功");
		}
    }
}

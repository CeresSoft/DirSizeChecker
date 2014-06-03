//=============================================================================
// システム名称　　　： ディレクトリサイズチェッカー
// サブシステム名　　： 
// 機能名　　　　　　： 
// ソースファイル名　： DirectoryData.cs
//-----------------------------------------------------------------------------
// 機能概要　　　　　： ディレクトリ情報の取得および容量の計算
//-----------------------------------------------------------------------------
// 改訂履歴    区分  改訂番号  社名)担当   内容
// 2014.06.02  新規  ----      CS)土田
//=============================================================================

using System;
using System.Data;
using System.IO;
using System.ComponentModel;

namespace DirSizeChecker
{
	/// <summary>
	/// ディレクトリ解析モジュール
	/// </summary>
    public class DirectoryData
    {
        private static log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// 進捗パーセンテージの初期値
		/// </summary>
		private const int PERCENT_ZERO = 0;

        /// <summary>
        /// 合計ファイルサイズの初期値（エラー値扱い）
        /// </summary>
        private const long SIZE_ERROR = -1L;

        /// <summary>
        /// ファイル数・ディレクトリ数カウントの初期値
        /// </summary>
        private const long COUNT_ZERO = 0L;

		//2014/05/30:削除:>>>>>ここから
        /// <summary>
        /// 配列の長さ0を判定するための定数
        /// </summary>
        //private const int LENGTH_ZERO = 0;

        /// <summary>
        /// テーブルカラム：ディレクトリ名
        /// </summary>
        //public const string COLUMN_NAME = "Name";

        /// <summary>
        /// テーブルカラム：合計ファイルサイズ
        /// </summary>
        //public const string COLUMN_SIZE = "Size";

		/// <summary>
		/// Disposeフラグ
		/// </summary>
		//private bool disposed = false;
		//2014/05/30:削除:<<<<<ここまで

		/// <summary>
		/// 検出したディレクトリ数
		/// </summary>
        private long foundDir = COUNT_ZERO;
		/// <summary>
		/// 解析したディレクトリ数
		/// </summary>
        private long successDir = COUNT_ZERO;

		/// <summary>
		/// 現在のパス
		/// </summary>
        private string currentPath = null;

		//2014/05/30:削除:>>>>>ここから
		/// <summary>
		/// ディレクトリの情報を格納するテーブル
		/// </summary>
		//2014/05/30:削除:>>>>>ここから
		//private DataTable table = null;

		/// <summary>
		/// テーブルをデータソースとして参照するためのデータビュー
		/// </summary>
        //private DataView dataView = null;

        /// <summary>
        /// データビュー
        /// </summary>
		//public DataView TableView
		//{
		//    get
		//    {
		//        //2014/05/30:変更:>>>>>ここから
		//        //return this.dataView;
		//        if (this.table == null)
		//        {
		//            return null;
		//        }

		//        return this.table.DefaultView;
		//        //2014/05/30:変更:>>>>>ここまで
		//    }
		//}
		//2014/05/30:削除:<<<<<ここまで

		/// <summary>
		/// データテーブルへの参照
		/// </summary>
		public DirectoryDataSet.DirectoriesDataTable Table { set; get; }

        /// <summary>
        /// 前回の解析で検出されたディレクトリの数
        /// </summary>
        public long LastFound
        {
            get { return this.foundDir; }
        }

        /// <summary>
        /// 前回の解析で処理が成功したディレクトリの数
        /// </summary>
        public long LastSucceeded
        {
            get { return this.successDir; }
        }

		// コンストラクタ
        public DirectoryData(){}

		//2014/05/30:削除:>>>>>ここから
        /// <summary>
        /// 使用データを初期化する。
        /// </summary>
		//public void Init()
		//{
		//    Logger.Debug("Init() 呼び出し");

		//    try
		//    {
		//        //2014/05/30:追加:>>>>>ここから
		//        if (this.table != null)
		//        {
		//            //初回でなければ何もせず終了
		//            Logger.Debug("すでに初期化が行われているため終了");
		//            return;
		//        }
		//        //2014/05/30:追加:<<<<<ここまで

		//        this.table = new DataTable();
		//        this.table.Columns.Add(COLUMN_DIR, typeof(string));
		//        this.table.Columns.Add(COLUMN_SIZE, typeof(long));

		//        //this.dataView = this.__table.DefaultView;

		//        //2014/05/29:削除:>>>>>ここから
		//        //this.clearDelegate = new ClearTableDelegate(this.table.Clear);
		//        //this.addDelegate = new AddDataDelegate(this.AddData);
		//        //2014/05/29:削除:<<<<<ここまで
		//    }
		//    catch (Exception ex)
		//    {
		//        Logger.WarnFormat("Init 処理中に例外が発生 (理由={0})", ex);
		//        return;
		//    }

		//    Logger.Debug("Init 成功");
		//}
		//2014/05/30:削除:>>>>>ここまで

		/// <summary>
		/// テーブルにデータを追加する
		/// </summary>
		/// <param name="name"></param>
		/// <param name="size"></param>
        private void AddData(string name, long size)
        {
			Logger.DebugFormat("AddData(\"{0}\", {1}) 呼び出し", name, size);

            try
            {
				//テーブルが存在しなければ終了
				if (this.Table == null)
                {
					Logger.Debug("テーブルへの参照が空であるため終了");
                    return;
                }

				//2014/05/30:変更:>>>>>ここから
				//DataRow row = this.table.NewRow();

                //カラムに値をセット
                //row[COLUMN_DIR] = dirName;
                //row[COLUMN_SIZE] = dirSize;

                //新しい行を追加
                //this.table.Rows.Add(row);

				DirectoryDataSet.DirectoriesRow row = this.Table.NewDirectoriesRow();

				//列に値をセット
				row.Name = name;
				row.Size = size;

				//新しい行を追加
				this.Table.Rows.Add(row);
				//2014/05/30:変更:<<<<<ここまで
            }
            catch (Exception ex)
            {
                Logger.WarnFormat("AddData 処理中に例外が発生 (理由={0})", ex);
                return;
            }

            Logger.Debug("AddData 成功");
        }

        /// <summary>
        /// 指定されたディレクトリを解析し、結果をテーブルに保存する。
		/// </summary>
		/// <param name="path">ディレクトリのパス。</param>
		/// <param name="bgWorker">結果を通知したいBackgroundWorker。</param>
        /// <returns></returns>
        public bool ReadDirectory(string path, BackgroundWorker bgWorker)
        {
            Logger.DebugFormat("ReadDirectory(\"{0}\") 呼び出し", path);

            bool ret = false;

            try
            {
                //目的となるパスが実在しなければ終了
                bool exists = Directory.Exists(path);
                if (!exists)
                {
                    Logger.DebugFormat("{0} は存在しないため終了", path);
                    return false;
                }

				//2014/05/30:追加:>>>>>ここから
				if (this.Table == null)
				{
					Logger.Debug("テーブルへの参照が空であるため終了");
					return false;
				}
				//2014/05/30:削除:<<<<<ここまで

                //2014/05/29:削除:>>>>>ここから
                //if (this.addDelegate == null) { return false; }
                //if (this.clearDelegate == null) { return false; }
                //2014/05/29:削除:<<<<<ここまで

                //テーブルをクリア
				this.Table.Clear();
                //2014/05/29:追加:>>>>>ここから
                //ディレクトリ数カウントをリセット
                this.foundDir = COUNT_ZERO;
                this.successDir = COUNT_ZERO;
                //2014/05/29:追加:<<<<<ここまで

                //2014/05/29:削除:>>>>>ここから
                //if (form == null)
                //{
                //    this.clearDelegate();
                //} 
                //else
                //{
                //    form.Invoke(this.clearDelegate);
                //}
                //2014/05/29:削除:<<<<<ここまで

                //サブディレクトリの一覧を取得
                string[] dirs = Directory.GetDirectories(path);
                //取得できなければ終了
                if (dirs == null)
                {
                    Logger.Debug("サブディレクトリ一覧を取得できなかったため終了");
                    return false;
                }

                //すべてのサブディレクトリのサイズを計算
                foreach (string dir in dirs)
                {
                    DirectoryInfo di = new DirectoryInfo(dir);
                    string name = Path.GetFileName(dir);
					//2014/06/03:変更:>>>>>ここから
					//long size = GetDirectorySize(di);
					//nullチェックは呼び出し先でする
					long size = GetDirectorySize(di, bgWorker);
					//2014/06/03:変更:<<<<<ここまで

                    //行を追加
                    //2014/05/29:追加:>>>>>ここから
                    if (size > SIZE_ERROR)
                    {
                        this.AddData(name, size);
                    }
                    //2014/05/29:追加:<<<<<ここまで

                    //2014/05/29:削除:>>>>>ここから
                    //if (form == null)
                    //{
                    //    this.addDelegate(name, size);
                    //}
                    //else
                    //{
                    //    form.Invoke(this.addDelegate, name, size);
                    //}
                    //2014/05/29:削除:<<<<<ここまで
                }

                //解析が完了したらそのパスを現在位置として保存
                this.currentPath = path;

                ret = true;
            }
            catch (Exception ex)
            {
                Logger.WarnFormat("ReadDirectory 処理中に例外が発生 (理由={0})", ex);
                return false;
            }

            Logger.Debug("ReadDirectory 成功");
            return ret;
        }

        /// <summary>
        /// 現在参照しているディレクトリのフルパスを取得する。
        /// </summary>
        public string GetCurrentDirectory()
        {
            Logger.Debug("GetCurrentDirectory() 呼び出し / 成功");

            //現在のパスを返す
            return this.currentPath;
        }

		/// <summary>
		/// 現在参照しているディレクトリの親ディレクトリのフルパスを取得する。
		/// </summary>
		/// <returns>親ディレクトリのフルパス。見つからなかった場合は空文字。</returns>
        public string GetParentDirectory()
        {
            Logger.Debug("GetParentDirectory() 呼び出し");

            string ret = string.Empty;

            try
            {
                //パスが保存されていなければnullを返して終了
                if (this.currentPath == null)
                {
                    Logger.Debug("基準となるパスが設定されていないため終了");
					return string.Empty;
                }

                //親ディレクトリのDirectoryInfoインスタンスを取得
                DirectoryInfo di = Directory.GetParent(this.currentPath);
				bool isEmpty = string.IsNullOrEmpty(di.FullName);

                if((di != null) && (!isEmpty))
                {
                    //フルパスを返す
                    ret = di.FullName;
                }
            }
            catch (Exception ex)
            {
                Logger.WarnFormat("GetParentDirectory 処理中に例外が発生 (理由={0})", ex);
				return string.Empty;
            }

            Logger.Debug("GetParentDirectory 成功");
            return ret;
        }

        /// <summary>
        /// ディレクトリのサイズを取得する。
        /// </summary>
		/// <param name="dirInfo">サイズ計算をしたいディレクトリのDirectoryInfoインスタンス。</param>
		/// <param name="bgWorker">結果を通知したいBackgroundWorker。</param>
        /// <returns>サブフォルダも含む合計ファイルサイズ</returns>
		private long GetDirectorySize(DirectoryInfo dirInfo, BackgroundWorker bgWorker)
        {
            Logger.DebugFormat("GetDirectorySize({0}) 呼び出し", dirInfo);

            long size = SIZE_ERROR;

            try
            {
                //nullを渡されていたら終了
                if (dirInfo == null) {
                    Logger.Debug("引数 dirInfo が null のため終了");
                    return SIZE_ERROR;
                }

                //見つかったディレクトリ数に可算
				//※例外発生前に可算すること
				this.foundDir++;

				//2014/06/03:追加:>>>>>ここから
				//進捗を通知
				//※パーセンテージは算出できないのでゼロ固定
				bgWorker.ReportProgress(PERCENT_ZERO, this.foundDir);
				//2014/06/03:追加:>>>>>ここまで

                //サブディレクトリ一覧取得
				//※アクセス権限がないときは例外（UnauthorizedAccessException）発生
                DirectoryInfo[] dis = dirInfo.GetDirectories();

				//2014/05/30:変更:>>>>>ここから
				//if (dis.Length > LENGTH_ZERO)
                //サブディレクトリが無ければ空の配列が返るが、nullチェックをしておく
				if (dis != null)
				//2014/05/30:変更:>>>>>ここまで
				{
                    foreach (DirectoryInfo di in dis)
                    {
						//ディレクトリサイズを可算
						//2014/06/03:変更:>>>>>ここから
						//size += this.GetDirectorySize(di);
						size += this.GetDirectorySize(di, bgWorker);
						//2014/06/03:変更:>>>>>ここまで
                    }
                }

                //ファイル一覧取得
                FileInfo[] fis = dirInfo.GetFiles();

				//2014/05/30:変更:>>>>>ここから
                //if (fis.Length > LENGTH_ZERO)
				//ファイルが無ければ空の配列が返るが、nullチェックをしておく
				if(fis != null)
				//2014/05/30:変更:>>>>>ここまで
				{
                    foreach (FileInfo fi in fis)
                    {
                        //ファイルサイズを可算
                        size += fi.Length;
                    }
                }

                //正常に解析できたら成功数に可算
                this.successDir++;
            }
            catch (UnauthorizedAccessException unauth)
            {
                //dirInfo.GetDirectories()で起きる例外
                Logger.WarnFormat("アクセス権限がないため終了 (詳細={0})", unauth);

                return SIZE_ERROR;
            }
            catch (Exception ex)
            {
                Logger.WarnFormat("GetDirectorySize 処理中に例外が発生 (理由={0})", ex);

				return SIZE_ERROR;
            }

            Logger.Debug("GetDirectorySize 成功");

            //結果を返す
            return size;
        }

		//2014/05/30:削除:>>>>>ここから
        /// <summary>
        /// IDisposable実装
        /// </summary>
		//public void Dispose()
		//{
		//    this.Dispose(true);
		//    GC.SuppressFinalize(this);
		//}

		///// <summary>
		///// IDisposable実装
		///// </summary>
		///// <param name="disposing"></param>
		//public void Dispose(bool disposing)
		//{
		//    if (!this.disposed)
		//    {
		//        if (disposing)
		//        {
		//            if (this.table != null)
		//            {
		//                this.table.Dispose();
		//            }

		//            this.table = null;
		//            this.disposed = true;
		//        }
		//    }
		//}
		//2014/05/30:削除:<<<<<ここから
    }
}

//=============================================================================
// システム名称　　　： ディレクトリサイズチェッカー
// サブシステム名　　： 
// 機能名　　　　　　： 
// ソースファイル名　： VisualButton.cs
//-----------------------------------------------------------------------------
// 機能概要　　　　　： ロールオーバー機能付きボタン
//-----------------------------------------------------------------------------
// 改訂履歴    区分  改訂番号  社名)担当   内容
// 2014.06.02  新規  ----      CS)土田
//=============================================================================

using System;
using System.Drawing;
using System.Windows.Forms;

namespace DirSizeChecker
{
    /// <summary>
    /// 拡張画像ボタン
    /// </summary>
    public partial class VisualButton : Button
    {
        private static log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// デフォルトの画像。
		/// </summary>
		private Bitmap _imageOnUp = null;
		/// <summary>
		/// カーソルが乗っている時の画像。
		/// </summary>
		private Bitmap _imageOnHover = null;
		/// <summary>
		/// マウスでボタンを押下している時の画像。
		/// </summary>
		private Bitmap _imageOnDown = null;
		/// <summary>
		/// ボタンが無効になっている時の画像。
		/// </summary>
		private Bitmap _imageDisabled = null;

        /// <summary>
        /// デフォルトの画像を取得、設定します。
        /// </summary>
        public Bitmap ImageOnUp
        {
			set
			{
				this._imageOnUp = value;
			}
			get
			{
				return this._imageOnUp;
			}
        }

        /// <summary>
		/// カーソルが乗っている時の画像を取得、設定します。
        /// </summary>
        public Bitmap ImageOnHover
		{
			set
			{
				this._imageOnHover = value;
			}
			get
			{
				return this._imageOnHover;
			}
        }

        /// <summary>
		/// マウスでボタンを押下している時の画像を取得、設定します。
        /// </summary>
        public Bitmap ImageOnDown
		{
			set
			{
				this._imageOnDown = value;
			}
			get
			{
				return this._imageOnDown;
			}
        }

        /// <summary>
		/// ボタンが無効になっている時の画像を取得、設定します。
        /// </summary>
        public Bitmap ImageDisabled
		{
			set
			{
				this._imageDisabled = value;
			}
			get
			{
				return this._imageDisabled;
			}
        }


        /// <summary>
        /// ボタンの有効状態が変わった時の処理。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnabledChanged(EventArgs e)
        {
			base.OnEnabledChanged(e);

            try
            {
                //Enabledには変化後の新しい値が入っている
                if (this.Enabled)
                {
                    if (this._imageOnUp != null)
                    {
                        //有効なら標準画像をセット
                        this.BackgroundImage = this._imageOnUp;
                    }
                }
                else
                {
                    if (this._imageDisabled != null)
                    {
                        //無効なら無効状態の画像をセット
                        this.BackgroundImage = this._imageDisabled;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WarnFormat("VisualButton_EnabledChanged 処理中に例外が発生 (理由={0})", ex);
            }
        }

        /// <summary>
        /// マウスでボタンを押した直後の処理。
        /// </summary>
        /// <param name="mevent"></param>
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
			base.OnMouseDown(mevent);

            try
            {
                if (this._imageOnDown != null)
                {
                    //押下中画像をセット
                    this.BackgroundImage = this._imageOnDown;
                }
            }
            catch (Exception ex)
            {
                Logger.WarnFormat("VisualButton_MouseDown 処理中に例外が発生 (理由={0})", ex);
            }
        }

        /// <summary>
        /// ボタンの上にカーソルが乗った時の処理。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseEnter(EventArgs e)
        {
			base.OnMouseEnter(e);

            try
            {
                if (this._imageOnHover != null)
                {
                    //マウスオーバー画像をセット
                    this.BackgroundImage = this._imageOnHover;
                }
            }
            catch (Exception ex)
            {
                Logger.WarnFormat("VisualButton_MouseEnter 処理中に例外が発生 (理由={0})", ex);
            }
        }

        /// <summary>
        /// ボタンの上からカーソルが離れた時の処理。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
			base.OnMouseLeave(e);

            try
            {
				//ボタンが無効になった時、カーソルが乗っている場合はこのイベントが発生するので、
				//無効状態で呼ばれた時は何もせず終了する
				if (!this.Enabled) { return; }

				if (this._imageOnUp != null)
                {
                    //標準画像をセット
					this.BackgroundImage = this._imageOnUp;
                }
            }
            catch (Exception ex)
            {
                Logger.WarnFormat("VisualButton_MouseLeave 処理中に例外が発生 (理由={0})", ex);
            }
        }

        /// <summary>
        /// このボタンがフォームに配置される直前の処理。
        /// </summary>
        /// <param name="levent"></param>
        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);

            try
            {
                //ImageOnUpが空でないなら優先的にセット
                if (this._imageOnUp != null)
                {
                    this.BackgroundImage = this._imageOnUp;
                }
            }
            catch (Exception ex)
            {
                Logger.WarnFormat("VisualButton_Layout 処理中に例外が発生 (理由={0})", ex);
            }
        }
    }
}

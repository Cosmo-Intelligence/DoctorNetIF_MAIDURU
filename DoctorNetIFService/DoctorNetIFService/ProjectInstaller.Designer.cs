namespace DoctorNetIFService
{
	partial class DoctorNetIFServiceProjectInstaller
    {
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region コンポーネント デザイナで生成されたコード

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.DoctorNetIFServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
			this.DoctorNetIFServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // DoctorNetIFServiceProcessInstaller
            // 
            this.DoctorNetIFServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
			this.DoctorNetIFServiceProcessInstaller.Password = null;
			this.DoctorNetIFServiceProcessInstaller.Username = null;
            // 
            // DoctorNetIFServiceInstaller
            // 
            this.DoctorNetIFServiceInstaller.Description = "ドクターネットインタフェース機能";
			this.DoctorNetIFServiceInstaller.DisplayName = "FFMS_DoctorNetIFService";
			this.DoctorNetIFServiceInstaller.ServiceName = "FFMS_DoctorNetIFService";
            // 
            // DoctorNetIFServiceProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.DoctorNetIFServiceProcessInstaller,
            this.DoctorNetIFServiceInstaller});

		}

		#endregion

		private System.ServiceProcess.ServiceProcessInstaller DoctorNetIFServiceProcessInstaller;
		private System.ServiceProcess.ServiceInstaller DoctorNetIFServiceInstaller;
	}
}
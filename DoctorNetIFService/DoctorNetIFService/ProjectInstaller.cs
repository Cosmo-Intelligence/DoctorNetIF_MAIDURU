using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;


namespace DoctorNetIFService
{
	[RunInstaller(true)]
	public partial class DoctorNetIFServiceProjectInstaller : Installer
	{
		public DoctorNetIFServiceProjectInstaller()
		{
			InitializeComponent();
		}
	}
}

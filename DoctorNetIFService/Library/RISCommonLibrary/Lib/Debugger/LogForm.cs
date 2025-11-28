using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace RISCommonLibrary.Lib.Debugger
{
	public partial class LogForm : Form
	{
		public LogForm()
		{
			InitializeComponent();
		}

		private void LogForm_Load(object sender, EventArgs e)
		{
			Debug.Listeners.Add(new RichTextBoxWriterTraceListener(logRichTextBox, 3000));
		}

		private void HideButton_Click(object sender, EventArgs e)
		{
			Hide();
		}

		private void ClearButton_Click(object sender, EventArgs e)
		{
			logRichTextBox.Clear();
		}

	}
}

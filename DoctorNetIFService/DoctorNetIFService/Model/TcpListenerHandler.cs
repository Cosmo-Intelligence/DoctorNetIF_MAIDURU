using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DoctorNetIFService.Model
{
    public class TcpListenerHandler
    {
        /// <summary>
		/// log4netインスタンス
		/// </summary>
		private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IPEndPoint endPoint;

        private readonly TcpListener tcpListener;

        public TcpListenerHandler(IPEndPoint paramEndPoint)
        {
            endPoint = paramEndPoint;

            tcpListener = new TcpListener(endPoint);
        }

		public void Close()
        {
            tcpListener.Stop();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RISCommonLibrary.Lib.Msg.OrderRequestInfo
{
	class HISRISOrderRequestRootNodeInfo
	{
		public static NodeInfo H2RREQUEST_ROOT = new NodeInfo("REQUEST", "依頼再送要求ﾃﾞｰﾀ", NodeTypeEnum.ntAggregate, -1);
	}
}

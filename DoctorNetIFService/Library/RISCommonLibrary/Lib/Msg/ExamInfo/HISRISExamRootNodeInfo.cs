using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RISCommonLibrary.Lib.Msg.ExamInfo
{
	class HISRISExamRootNodeInfo
	{
		public static NodeInfo H2REXAM_ROOT = new NodeInfo("EXAM_ROOT", "放射線実施データ", NodeTypeEnum.ntAggregate, -1);
	}
}

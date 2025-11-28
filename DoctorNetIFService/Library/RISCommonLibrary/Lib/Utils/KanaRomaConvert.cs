using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace RISCommonLibrary.Lib.Utils
{
	/// <summary>
	/// 
	/// KanaRomaConvert の概要の説明です。
	/// 
	/// Copyright (C) 2009-2012, Yokogawa Medical Solutions Corporation
	/// 
	///	(Rev.)		(Date)			(ID / NAME)						(Comment)
	/// V1.00.00	: 2009.03.25	: 112478	/ A.Kobayashi		: original
	/// 
	/// </summary>
	public class KanaRomaConvert
	{
		private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		// カナ→ローマ字変換用ファイル名
		private const string fileName = "\\KanaRomaList.txt";
		// 最大文字数
		private const int maxCount = 300;
		// "ッ"の変換文字列
		private const string ltuConst = "LTU";

		// 変換用ファイルの読込成否
		private bool fileReadFlg;
		// カナ変換リスト
		private string[] kanaList = new string[maxCount];
		// ローマ字変換リスト
		private string[] romaList = new string[maxCount];
		// 撥音
		private int hatuon = 0;
		// 促音
		private int sokuon = 0;
		// 長音
		private int chouon = 0;
		// 姓名の最後の「ｳ」
		private int uText  = 0;
		// 大文字・小文字の指定
		private int caps   = 0;

		public KanaRomaConvert()
		{
			// 
			// TODO: コンストラクタ ロジックをここに追加してください。
			//

			// 変換用ファイルの読込を行う
			fileReadFlg = ReadKanaRomaList();
		}

		/// <summary>
		/// カナ→ローマ字変換用関数
		/// </summary>
		/// <param name="convertKana">カナ文字列</param>
		/// <returns>ローマ字文字列</returns>
		public string GetRomaConvert(string convertKana)
		{
			// 変換後のローマ字入力用
			string romaStr = "";

			_log.Debug("begin");
			try
			{
				// 変換用ファイル読込に成功した場合のみ
				if (fileReadFlg)
				{
					// カナ→ローマ字の変換を行う
					// 半角カナ形式に変換する
					string kanaStr = Strings.StrConv(convertKana.Trim(), VbStrConv.Narrow, 0);
					// 大文字に統一する
					kanaStr = Strings.StrConv(kanaStr, VbStrConv.Uppercase, 0);

					// 初期化
					bool ltuFlg			= false;
					string getKana		= "";
					string getRoma		= "";
					string beforeKana	= "";
					string afterKana	= "";
					string ltuStr		= "";

					//「ｯ」の単体の変換文字列を探す。
					for (int listCount = 0; listCount < maxCount; listCount++)
					{
						if (kanaList[listCount].Equals("ｯ")) 
						{
							ltuStr = romaList[listCount];
							break;
						}
					}
					// 見つからなかった場合はconst文字を使う
					if (ltuStr.Trim().Equals(""))
					{
						ltuStr = ltuConst;
					}

					int kanaCount = 0;
					//１文字づつ処理
					while (kanaCount < kanaStr.Length)
					{
						getKana = kanaStr.Substring(kanaCount, 1);
						if (kanaCount < kanaStr.Length - 1)
						{
							afterKana = kanaStr.Substring(kanaCount + 1, 1);
						}
						else
						{
							afterKana = "";
						}
						if (kanaCount == 0)
						{
							beforeKana = "";
						}
						else
						{
							beforeKana = kanaStr.Substring(kanaCount - 1, 1);
						}

						//「ｯ」は次で処理するので飛ばす
						if (getKana.Equals("ｯ"))
						{
							if (ltuFlg)
							{
								romaStr = romaStr + ltuStr;
							}
							ltuFlg = true;
							kanaCount++;

							continue;
						}
						//「ﾞ」、「ﾟ」は結合して処理する
						if ((afterKana.Equals("ﾞ")) ||
							(afterKana.Equals("ﾟ")))
						{
							getKana = getKana + afterKana;
							kanaCount++;
							// 更にその次を見る
							if (kanaCount < kanaStr.Length - 1)
							{
								afterKana = kanaStr.Substring(kanaCount + 1, 1);
							}
							else
							{
								afterKana = "";
							}
						}
						//「ｧ」「ｨ」「ｩ」「ｪ」「ｫ」
						//「ｬ」「ｨ」「ｭ」「ｪ」「ｮ」
						//は結合して処理する
						if ((afterKana.Equals("ｧ")) ||
							(afterKana.Equals("ｨ")) ||
							(afterKana.Equals("ｩ")) ||
							(afterKana.Equals("ｪ")) ||
							(afterKana.Equals("ｫ")) ||
							(afterKana.Equals("ｬ")) ||
							(afterKana.Equals("ｭ")) ||
							(afterKana.Equals("ｮ")))
						{
							// 結合した文字が変換リストに存在しない場合はそのまま処理
							getRoma = "";
							for (int listCount = 0; listCount < maxCount; listCount++)
							{
								if (kanaList[listCount].Equals(getKana + afterKana))
								{
									getRoma = romaList[listCount];
									break;
								}
							}
							if (!getRoma.Equals(""))
							{
								getKana = getKana + afterKana;
								kanaCount++;
								// 更にその次を見る
								if (kanaCount < kanaStr.Length - 1)
								{
									afterKana = kanaStr.Substring(kanaCount + 1, 1);
								}
								else
								{
									afterKana = "";
								}
							}
						}
						//「ｳ」は姓、名の最後であれば飛ばす
						if (getKana.Equals("ｳ"))
						{
							if (afterKana.Trim().Equals(""))
							{
								if (uText == 1)
								{
									getKana = afterKana;
									kanaCount++;
									// 更にその次を見る
									if (kanaCount < kanaStr.Length - 1)
									{
										afterKana = kanaStr.Substring(kanaCount + 1, 1);
									}
									else
									{
										afterKana = "";
									}
									//ループを抜ける
									continue;
								}
							}
						}
						//空白は無条件に299番目とする
						if (getKana.Equals(" "))
						{
							if (ltuFlg)
							{
								getRoma = ltuStr + romaList[299];
								ltuFlg = false;
							}
							else
							{
								getRoma = romaList[299];
							}
						}
						else 
						{
							getRoma = "";
							for (int listCount = 0; listCount < maxCount; listCount++)
							{
								if (kanaList[listCount].Equals(getKana))
								{
									getRoma = romaList[listCount];
									break;
								}
							}
							if (getRoma.Equals(""))
							{
								if (ltuFlg)
								{
									getRoma = ltuStr;
									ltuFlg = false;
								}
								getRoma = getRoma + " ";
							}
							else if (getRoma.Equals(" "))
							{
								if (ltuFlg)
								{
									getRoma = ltuStr + " ";
									ltuFlg = false;
								}
							}
							else 
							{
								//撥音－前に「ﾝ」がある場合
								if (beforeKana.Equals("ﾝ"))
								{
									if ((getKana.Equals("ｱ")) ||
										(getKana.Equals("ｲ")) ||
										(getKana.Equals("ｳ")) ||
										(getKana.Equals("ｴ")) ||
										(getKana.Equals("ｵ")))
									{
										if (hatuon == 0)
										{
											//訓令式－nのまま
											//getRoma = getRoma;
										}
										else if (hatuon == 2)
										{
											//nn
											getRoma = "N" + getRoma;
										}
									}
									if ((getRoma.Substring(0,1).Equals("M")) ||
										(getRoma.Substring(0,1).Equals("B")) ||
										(getRoma.Substring(0,1).Equals("P")))
									{
										if (hatuon == 1)
										{
											//ﾍﾎﾞﾝ式－m,b,pの前にnの変りにmをおく
											romaStr = romaStr.Substring(0, romaStr.Length - 1);
											getRoma = "M" + getRoma;
										}
									}
								}

								//促音－「ｯ」
								if (ltuFlg)
								{
									// 続く文字が
									//「A」「I」「U」「E」「O」「N」
									// の場合は固定文字
									if ((getRoma.Substring(0, 1).Equals("A")) ||
										(getRoma.Substring(0, 1).Equals("I")) ||
										(getRoma.Substring(0, 1).Equals("U")) ||
										(getRoma.Substring(0, 1).Equals("E")) ||
										(getRoma.Substring(0, 1).Equals("O")) ||
										(getRoma.Substring(0, 1).Equals("N")))
									{
										getRoma = ltuStr + getRoma;
									}
									else
									{
										if (sokuon == 0)
										{
											//訓令式－子音を重ねる
											getRoma = getRoma.Substring(0, 1) + getRoma;
										}
										else if (sokuon == 1)
										{
											//ﾍﾎﾞﾝ式－chi,cha,chu,choに限り前にtをおく
											if ((getRoma.Equals("CHI")) ||
												(getRoma.Equals("CHA")) ||
												(getRoma.Equals("CHU")) ||
												(getRoma.Equals("CHO")))
											{
												getRoma = "T" + getRoma;
											}
											else 
											{ 
												//ﾍﾎﾞﾝ式－子音を重ねる
												getRoma = getRoma.Substring(0, 1) + getRoma;
											}
										}
									}
									ltuFlg = false;
								}

								//長音－「-」
								if (getRoma.Equals("-"))
								{
									if (chouon == 0)
									{
										//そのまま
										//getRoma = getRoma;
									}
									else if (chouon == 1)
									{
										//母音字を並べる
										if (romaStr.Length > 0)
										{
											getRoma = romaStr.Substring(romaStr.Length - 1, 1);
										}
										else 
										{
											//getRoma = getRoma;
										}
									}
								}
							}
						}
				
						//１文字づつを結合
						romaStr = romaStr + getRoma;
						//次へ
						kanaCount++;
					}

					//最後に「ｯ」が残っている場合
					if (ltuFlg)
					{
						romaStr = romaStr + ltuStr;
					}

					// 大文字・小文字のチェック
					if (caps == 1)
					{
						// 大文字
						romaStr = Strings.StrConv(romaStr, VbStrConv.Uppercase, 0);
					}
					else if (caps == 2)
					{
						// 1文字目のみ大文字
						romaStr = Strings.StrConv(romaStr, VbStrConv.ProperCase, 0);
					}
					else
					{
						// 小文字
						romaStr = Strings.StrConv(romaStr, VbStrConv.Lowercase, 0);
					}
				}
			}
			catch(Exception ex)
			{
				_log.Fatal(ex);
			}
			finally
			{
				_log.Debug("end");
			}
			// 変換文字列を返す
			return romaStr;
		}

		/// <summary>
		/// カナ→ローマ字変換用ファイル読込
		/// </summary>
		/// <returns>true=成功 false=失敗</returns>
		private bool ReadKanaRomaList()
		{
			bool returnFlg = false;
			_log.Debug("begin");
			try
			{
				// ファイルPath
				string filePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + fileName;

				//ファイルが存在しない場合は処理しない
				if (!File.Exists(filePath))
				{
					string msg = "設定されたカナ→ローマ字変換用ファイルが存在しませんでした。変換は行われません。";
					_log.Fatal(msg + "\r\n" + filePath);
					return false;
				}

				// ファイル読込
				using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.GetEncoding("Shift_JIS")))
				{
					// カナ行・ローマ字行のカウント
					int kanaCount = 0;
					int romaCount = 0;

					string line;

					// 1行ずつ読み込む
					while ((line = sr.ReadLine()) != null)
					{
						// 列の1文字目はカナ・ローマ字の分類
						string lineTitle= Strings.StrConv(line.Substring(0, 1), VbStrConv.Uppercase, 0);
						// 実データ部分以外の項目は飛ばす
						if (lineTitle.Equals("/")) continue;
						// 実データ部分
						string lineData	= line.Substring(3, line.Length - 3);
						string[] splitList = lineData.Split('，');

						// 1文字ずつ読み込む
						for (int i = 0; i < splitList.Length - 1; i++)
						{
							string readStr = splitList[i].Trim();
							// 先頭と最後に「"」があるならばリムーブ
							if( readStr.Length >= 2 )
							{
								if( readStr[0] == '\"' && readStr[readStr.Length - 1] == '\"' )
								{
									readStr = readStr.Substring(1, readStr.Length - 2);
								}
							}
							// フラグ行の場合
							if (lineTitle.Equals("F"))
							{
								switch(i)
								{
                                    // 撥音
									case 0:	hatuon = int.Parse(readStr);	break;
									// 促音
									case 1:	sokuon = int.Parse(readStr);	break;
									// 長音
									case 2:	chouon = int.Parse(readStr);	break;
									// 姓名の最後の「ｳ」
									case 3:	uText  = int.Parse(readStr);	break;
									// 大文字・小文字の指定
									case 4:	caps   = int.Parse(readStr);	break;
								}
							}
							// カナ行の場合
							if (lineTitle.Equals("K"))
							{
								kanaList[kanaCount] = Strings.StrConv(readStr, VbStrConv.Uppercase, 0);
								kanaCount++;
							}
							// ローマ字行の場合
							if (lineTitle.Equals("R"))
							{
								romaList[romaCount] = Strings.StrConv(readStr, VbStrConv.Uppercase, 0);
								romaCount++;
							}
						}
					}
					// 読込データが足りない場合は失敗
					if (!((kanaCount == 300) && (romaCount == 300))) 
					{
						returnFlg = false;
					}
				}
				// ファイル読込成功
				returnFlg = true;
			}
			catch(Exception ex)
			{
				_log.Fatal(ex);
				// ファイル読込失敗
				returnFlg = false;
			}
			finally
			{
				_log.Debug("end");
			}
			return returnFlg;
		}
	}
}

YFY TW在跑時,出現以下訊息:
無法載入檔案或組件 ICSharpCode.SharpZipLib version=0.86.0.518,culture=neutral,PublicKeyToken=1b03e6acf1164f73'
或其相依性的其中之一。
系統找不到指定的檔案。
檔案名稱:ICSharpCode.SharpZipLib version=0.86.0.518,culture=neutral,PublicKeyToken=1b03e6acf1164f73'
於NPOI.OpenXml4Net.OPC.ZipPackage..ctor
於NPOI.OpenXml4Net.OPC.OPCPackage.Open
於NPOI.Util.PackageHelper.Open
於NPOI.XSSF.UserModel.XSSFWorkbook..ctor
(怪,我單機沒出現)

.XML要掛嗎.先不掛,有問題,再來掛.

==============================
單機測試
AP	dll	NPOI.Version
net4.0	net3.5	2.0.6.0+net2.0	無法載入檔案或組件 'NPOI, Version=2.0.6.0, Culture=neutral, PublicKeyToken=0df73ec7942b34e1' 或其相依性的其中之一。 找到的組件資訊清單定義與組件參考不符。 
net4.0	net4.0	2.2.0.0+net2.0	OK
net4.0	net4.0	2.2.0.0+net4.0	OK
net4.0	net3.5	2.2.0.0+net2.0	OK


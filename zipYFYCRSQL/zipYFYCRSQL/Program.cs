using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SevenZip;

namespace zipYFYCRSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            //加入參考:sevenzipsharp
            //加入項目:7z.dll 內容.永遠複製
            //test();

            YFYCNCR();
        }

        private static void test()
        {
            string sFile = System.IO.Path.Combine(Environment.CurrentDirectory, "123");
            CompressFiles(sFile);
        }

        private static void YFYCNCR()
        {
            string sFile = "";
            Console.WriteLine("~~ Start zip folder  ~~");

            Console.WriteLine("~~ Start1 SQLFunction_CR_query");
            sFile = System.IO.Path.Combine(Environment.CurrentDirectory, "SQLFunction_CR_query");
            CompressFiles(sFile);

            Console.WriteLine("~~ Start2 SQLFunction_CR_query_select");
            sFile = System.IO.Path.Combine(Environment.CurrentDirectory, "SQLFunction_CR_query_select");
            CompressFiles(sFile);

            Console.WriteLine("~~ Start3 SQLFunction_HQ");
            sFile = System.IO.Path.Combine(Environment.CurrentDirectory, "SQLFunction_HQ");
            CompressFiles(sFile);

            Console.WriteLine("~~ Start4 SQLFunction_MIDB");
            sFile = System.IO.Path.Combine(Environment.CurrentDirectory, "SQLFunction_MIDB");
            CompressFiles(sFile);

            Console.WriteLine("~~ Start5 SQLFunction_subDB_fn_Table");
            sFile = System.IO.Path.Combine(Environment.CurrentDirectory, "SQLFunction_subDB_fn_Table");
            CompressFiles(sFile);

            Console.WriteLine("~~ Start6 SQLFunction_subDB_query");
            sFile = System.IO.Path.Combine(Environment.CurrentDirectory, "SQLFunction_subDB_query");
            CompressFiles(sFile);

            Console.WriteLine("~~     The  end      ~~");
            Console.ReadLine();
        }
        public static void CompressFiles(string sourceCodeFolder )
        {
            string targetFolder = Environment.CurrentDirectory;
            string targetFolderName=sourceCodeFolder+".zip";
            //string sourceCodeFolder = @"D:\123"; 
            if (System.IO.Directory.Exists(sourceCodeFolder))
            { 
                if (System.IO.Directory.Exists(targetFolder))
                {
                    //Console.WriteLine("start " + sourceCodeFolder);
                    CompressFiles(sourceCodeFolder, targetFolderName);
                    Console.WriteLine("                                          end ");
                }
            }
        }

        private static void CompressFiles(string sourceCodeFolder, string targetFolderName)
        {
            string sFile = System.IO.Path.Combine(Environment.CurrentDirectory, "7z.dll");
            // Specify where 7z.dll DLL is located
            SevenZipCompressor.SetLibraryPath(sFile);
            SevenZipCompressor sevenZipCompressor = new SevenZipCompressor();
            sevenZipCompressor.CompressionLevel = SevenZip.CompressionLevel.Ultra;
            sevenZipCompressor.CompressionMethod = CompressionMethod.Lzma;
            sevenZipCompressor.ArchiveFormat = OutArchiveFormat.Zip;
            //sevenZipCompressor.CompressionMode = CompressionMode.Create;
            //sevenZipCompressor.DirectoryStructure = false;//not it.
            //sevenZipCompressor.EncryptHeaders = true;//加密
            //sevenZipCompressor.EventSynchronization = EventSynchronizationStrategy.Default;
            //sevenZipCompressor.FastCompression = false;
            //sevenZipCompressor.IncludeEmptyDirectories = false;
            sevenZipCompressor.PreserveDirectoryRoot = true;
            sevenZipCompressor.CompressDirectory(sourceCodeFolder, targetFolderName);
            // Compress the directory and save the file in a yyyyMMdd_project-files.7z format (eg. 20141024_project-files.7z
            //sevenZipCompressor.CompressDirectory(sourceCodeFolder, Path.Combine(targetFolder, string.Concat(DateTime.Now.ToString("yyyyMMdd"), "_project-files.7z")));
        }
        /// <summary>
        /// 壓縮.未測試過
        /// </summary>
        /// <param name="archiveName"></param>
        /// <param name="fullFileNames"></param>
        /// <returns></returns>
        public static string CompressFiles2(string archiveName, params string[] fullFileNames)
        {
            try
            {
                string fileExt = Path.GetExtension(archiveName).ToLower();
                if (fileExt == ".7z")
                {
                    var compressor = new SevenZipCompressor() { ArchiveFormat = OutArchiveFormat.SevenZip };
                    compressor.CompressFiles(archiveName, fullFileNames);
                }
                else if (fileExt == ".zip")
                {
                    var compressor = new SevenZipCompressor() { ArchiveFormat = OutArchiveFormat.Zip };
                    compressor.CompressFiles(archiveName, fullFileNames);
                }

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// 解壓
        /// </summary>
        /// <param name="archiveName"></param>
        /// <param name="exportFolder"></param>
        public static void ExtractFiles(string archiveName, string exportFolder)
        {
            string sFile = System.IO.Path.Combine(Environment.CurrentDirectory, "7z.dll");
            SevenZip.SevenZipCompressor.SetLibraryPath(sFile);

            string fileExt = System.IO.Path.GetExtension(archiveName).ToLower();
            if (fileExt == ".7z" || fileExt == ".zip" || fileExt == ".rar")
            {
                //Can not load 7-zip library or internal COM error! Message: DLL file does not exist.
                var extractor = new SevenZip.SevenZipExtractor(archiveName);
                extractor.ExtractArchive(exportFolder);
            }
        }
    }
}

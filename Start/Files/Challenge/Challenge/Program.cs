using System;
using System.IO.Enumeration;
using System.Security.Cryptography.X509Certificates;
using System.Text;


string pptx = ".pptx"; string docx = ".docx"; string xlsx = ".xlsx";
int totalFiles = 0; int totalDocs = 0; int totalPpts = 0; int totalXls = 0;
float totalFileSize = 0; float totalDocSize = 0; float totalPptSize = 0; float totalXlsSize = 0;
string outputFileName = "result.txt";

(string challengeDir, string fileDir, string basedir) dirs = getDirs();
DirectoryInfo fileDirectory = new DirectoryInfo(dirs.fileDir);

foreach (FileInfo file in fileDirectory.EnumerateFiles()) {
	if (!isOfficeFile(file.Name)) continue;
	totalFiles++;
	totalFileSize += file.Length;
	if (file.Name.EndsWith(docx)) {
		totalDocs++; totalDocSize += file.Length;
	}else if (file.Name.EndsWith(pptx)){
		totalPpts++; totalPptSize += file.Length;
	}else if (file.Name.EndsWith(xlsx)){
		totalXls++; totalXlsSize += file.Length;
	}
}

string fullOutputFileName = dirs.basedir + outputFileName;
if (File.Exists(fullOutputFileName)) { File.Delete(fullOutputFileName); }

using (StreamWriter sw = File.CreateText(dirs.basedir+outputFileName))
{
	sw.WriteLine("~~~~ Results ~~~~");
	sw.WriteLine($"Total Files: {totalFiles}");
	sw.WriteLine($"Excel Count: {totalXls}");
	sw.WriteLine($"Word Count: {totalDocs}");
	sw.WriteLine($"PowerPoint Count: {totalPpts}");
	sw.WriteLine("----");
	sw.WriteLine($"Total Size: {totalFileSize:N0}");
	sw.WriteLine($"Excel Size: {totalXlsSize:N0}");
	sw.WriteLine($"Word Size: {totalDocSize:N0}");
	sw.WriteLine($"PowerPoint Size: {totalPptSize:N0}");
}


(string, string, string) getDirs() {
	string currdir = Directory.GetCurrentDirectory();

	string fileFolderName = "FileCollection";
	string challengeFolderName = "Challenge";

	DirectoryInfo currentDirInfo = new DirectoryInfo(currdir);
	StringBuilder sb = new StringBuilder();
	try
	{
		sb.Append(currentDirInfo.Parent.Parent.Parent.Parent.ToString());
	}
	catch (Exception e)
	{
		Console.WriteLine($"error encountered: {e.ToString()}");
	}
	sb.Append("\\");
	string basedir = sb.ToString();
	return (basedir+challengeFolderName, basedir+fileFolderName, basedir);
}


bool isOfficeFile(string fileName) {
	
	return fileName.EndsWith(pptx) || fileName.EndsWith(docx) || fileName.EndsWith(xlsx);
}
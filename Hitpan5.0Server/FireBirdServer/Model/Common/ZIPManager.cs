using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.IO;
namespace WebServiceServer.Model.Common
{
    class ZIPManager
    {
        internal void Zip(string FilePath,string ZipPath) 
        {
            bool isSucc = true;
            using(FileStream fsRead= File.OpenRead(FilePath))
	        {
                using (FileStream fsWrite = File.OpenWrite(ZipPath))
                {
                    using (GZipStream zipStream = new GZipStream(fsWrite,CompressionMode.Compress))
                    {
                        int ReadNum=0;
                        byte[] readBasket= new byte[1024];
                        while ((ReadNum=fsRead.Read(readBasket,0,readBasket.Length))>0)
	                    {
                            try
                            {
                                zipStream.Write(readBasket, 0, ReadNum);
                            }
                            catch (Exception)
                            {
                                if (ReadNum > 0)
                                {
                                    isSucc=false;
                                }                                
                                break;
                            }
	                    }
                    }
                }
	        }
            if (!isSucc)
            {
                throw new Exception("파일 압축이 실패하였습니다");
            }
        }//End of Zip

        internal void UnZip(string FilePath, string ZipPath)
        {
            bool isSucc = true;
            using (FileStream fsRead = File.OpenRead(ZipPath))
            {
                using (FileStream fsWrite = File.OpenWrite(FilePath))
                {
                    using (GZipStream zipStream = new GZipStream(fsRead, CompressionMode.Decompress))
                    {
                        int ReadNum = 0;
                        byte[] readBasket = new byte[1024];
                        while ((ReadNum=zipStream.Read(readBasket,0,readBasket.Length))>0)
                        {
                            try
                            {
                                fsWrite.Write(readBasket,0,ReadNum);
                            }
                            catch (Exception ex)
                            {
                                if (ReadNum>0)
                                {
                                    isSucc = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (!isSucc)
            {
                throw new Exception("파일 압축해제가 실패하였습니다");
            }
        }//End of Zip
    }
}

using System;

public class File
{
	public File(int id, string filename, string extension, byte[] data)
	{
        Id = id;
        FileName = filename;
        Extension = extension;
        Data = data;
    }
    public int Id { get; private set; }
    public string FileName { get; private set; }
    public string Extension { get; private set; }
    public byte[] Data { get; private set; }
}

namespace Example;

public class FileReader
{
    private int _pointer = 0;
    private string _fileContent;
    public FileReader(string fileContent)
    {
        _pointer = 0;
        _fileContent = fileContent;
    }

    public int file4(Char[] arr)
    {
        int count = 0;
        while (count < 4 && _pointer < _fileContent.Length)
        {
            arr[count++] = _fileContent[_pointer++];
        }
        return count;
    }
}

public class FileNReader
{
    private readonly FileReader _fileReader;
    public FileNReader(string fileContent)
    {
        _fileReader = new FileReader(fileContent);
    }
    public int NFile(char[] buffer, int n)
    {
        int totalRead = 0;

        char[] tempBuffer = new char[4];
        while (totalRead < n)
        {
            int count =_fileReader.file4(tempBuffer);
            if (count == 0)
            {
                //end of the file reach
                return totalRead;
            }

            for (int i = 0; i < count && totalRead < n; i++)
            {
                buffer[totalRead++] = tempBuffer[i];
            }
        }

        return totalRead;
    }
}
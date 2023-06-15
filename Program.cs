
string filePath = "c:\\temp.json";
List<string> resultList = new List<string>();

try
{
    // Read the text file
    string fileContent = File.ReadAllText(filePath);

    // Find instances of "generic":
    int currentIndex = 0;
    while (currentIndex < fileContent.Length)
    {
        int startIndex = fileContent.IndexOf("\"generic\":", currentIndex);
        if (startIndex == -1)
            break;

        startIndex += "\"generic\":".Length;
        int endIndex = fileContent.IndexOf("\",", startIndex);

        if (endIndex == -1)
            break;

        string extractedString = fileContent.Substring(startIndex, endIndex - startIndex).Replace("");
        resultList.Add(extractedString);
        currentIndex = endIndex + 2; // Move the currentIndex beyond the found string
    }

    // Output the extracted strings
    Console.WriteLine("Extracted Strings:");
    foreach (string extractedString in resultList)
    {
        Console.WriteLine(extractedString);
    }
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}

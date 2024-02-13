List<Student> students = await FileService.ReadFromFileAsync("adatok.txt");

List<Student> students2 =await FileService.ReadFromFileAsyncMethod2("adatok.txt");

List<Student> students3 = await FileService.ReadFromFileAsyncMethod3("adatok.txt");

Console.ReadKey();
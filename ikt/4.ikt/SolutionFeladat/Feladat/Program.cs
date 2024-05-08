using Feladat;

List<JoinedStudentData> joinedStudentsDatas = await DataService.GetExistingData();

joinedStudentsDatas = await Menus.MainMenu(joinedStudentsDatas);

await DataService.WriteData(joinedStudentsDatas);
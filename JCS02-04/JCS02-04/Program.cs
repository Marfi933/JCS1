using JCS02_04;

FileOperations fileOperations = new FileOperations();
fileOperations.readStudentsWriteSecondyear(@"../../../studentiPredmetu.xml", @"../../../students.json");
fileOperations.readCovidWriteAverages(@"../../../covid.json", @"../../../covid-averages.xml");
fileOperations.deserializeSubjectsWriteFirstN(@"../../../predmetyKatedry.xml", @"../../../subjects.json");
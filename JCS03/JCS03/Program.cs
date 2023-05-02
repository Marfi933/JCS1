using JCS03;

IntMatrix prvni = new IntMatrix(2,2);
prvni.SetVal(0,0,2); prvni.SetVal(0,1,4); 
prvni.SetVal(1,0,6); prvni.SetVal(1,1,8);
prvni.Print();

IntMatrix druha = new IntMatrix(2,2);
druha.SetVal(0,0,1); druha.SetVal(0,1,3);
druha.SetVal(1,0,5); druha.SetVal(1,1,7);
druha.Print();

IntMatrix treti = prvni.AddMatrix(druha);
treti.Print();

Console.WriteLine(treti.SumOfVals());
Console.WriteLine(treti.NonZero());
treti.SetVal(0,0,0);
Console.WriteLine(treti.NonZero());
IntMatrix dalsi = IntMatrix.Ones(3, 3);
dalsi.Print();

IntMatrix ctvrta = prvni.MulMatrix(dalsi);
ctvrta.Print();

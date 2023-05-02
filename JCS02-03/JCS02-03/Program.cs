using JCS02_03;

PrintDirectoryInfo pdi = new PrintDirectoryInfo();
pdi.PrintDrives();
pdi.PrintAllDirectories(@"C:\Windows");

var matrix = new BinaryMatrix(3, 3);
matrix[0,0] = 1;
matrix[0,1] = 1;
matrix[0,2] = 0;
matrix[1,0] = 0;
matrix[1,1] = 1;
matrix[1,2] = 0;
matrix[2,0] = 1;
matrix[2,1] = 1;
matrix[2,2] = 1;
matrix.WriteMatrix("matrix.bin");
matrix.PrintMatrix();
var matrix2 = BinaryMatrix.ReadMatrix("matrix.bin");
matrix2.PrintMatrix();


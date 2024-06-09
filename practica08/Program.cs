/* PUNTO1
AccionInt a1 = (ref int i) => i = i * 2;
a1 += a1; //2+2 = 4
a1 += a1; //4+4 = 8
a1 += a1; //8+8 = 16
int i = 1;
Console.WriteLine(i);
a1(ref i);
Console.WriteLine(i);*/


Trabajador t1 = new Trabajador();
//t1.Trabajando = T1Trabajando;
t1.Trabajar();

void T1Trabajando(object? sender, EventArgs e)
=> Console.WriteLine("Se inició el trabajo");
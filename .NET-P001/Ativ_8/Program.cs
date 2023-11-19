
int num1 = 7; 
int num2 = 3; 
int num3 = 10;

bool comp1 = (num1 > num2) && (num3 == (num1 + num3));
bool comp2 = (num1 > num2);
bool comp3 = (num3 == (num1 + num3));

Console.WriteLine(comp1);
Console.WriteLine(comp2);
Console.WriteLine(comp3);
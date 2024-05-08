IPlane fighter = new FighterJet("f-35C", "fighter");
IPlane bomber = new Bomber("B-52", "heavy bomber");

for (int i = 0; i < 10; i++)
{
    fighter.Attack();
    bomber.Attack();
}
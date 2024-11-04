using System.Diagnostics.Contracts;
using System.Reflection.PortableExecutable;

class Wizard {

    public string name;
    public string spell;
    public string spell2;
    public string spell3;
    

    public int mana ;
    public int damage;
    public double esperienza;
    public int vita;

    public Wizard(string _name, string _spell,string _spell2,string _spell3){

        name = _name;
        spell = _spell;
        mana = 100;
        esperienza = 0.5f;
        spell2 = _spell2;
        spell3 = _spell3;


    }

    public void castSpell1(){

        esperienza += 0.5f;
        mana -= 25;
        damage = 30;
        Console.WriteLine(name + " lancia " + spell + " infliggendo " + damage + " danni");
        Console.WriteLine(name + " ha guadagnato " + esperienza + " punti esperienza\n" + name + " ha " + mana + " mana");
        
        
        
    }

    public void castSpell2(){
        esperienza += 0.5f;
        mana -= 40;
        if (name == "Medivh"){
            damage = 70;
            Console.WriteLine(name + " lancia " + spell2 + " infliggendo " + damage + " danni");
            Console.WriteLine(name + " ha guadagnato " + esperienza + " punti esperienza\n" + name + " ha " + mana + " mana");

        }
        else {
            damage = 50;
            Console.WriteLine(name + " lancia " + spell2 + " infliggendo " + damage + " danni");
            Console.WriteLine(name + " ha guadagnato " + esperienza + " punti esperienza\n" + name + " ha " + mana + " mana");
            
        }
        
        
    }
    public void castSpell3(){
        esperienza += 0.5f;
        mana += 40;
        Console.WriteLine(name + " lancia " + spell3 );
        Console.WriteLine(name + " ha guadagnato " + esperienza + " punti esperienza\n" + name + " ha " + mana + " mana");
        
    }

    

}
class Undead{

    public int Health = 150;
    public string name ;

    public Undead(string _name){

        name = _name;

    }
}



class Programm
{
    static void Main(string[] args)
    {
        Wizard wizard1 = new Wizard("Jaina Marefiero","Frostball","Fireball","Evocation"){

        };
        Wizard wizard2 = new Wizard ("Medivh","Shadowball","Chaosbolt","Drain Mana");

        Undead undead1 = new Undead("ghoul");
        
        

        Console.WriteLine("scegli il mago con cui vuoi combattere:\n" + wizard1.name + "\n" + wizard2.name);
        var sceltaMago = Console.ReadLine();
        Wizard magoScelto = null;
        var vita = 100;
        switch(sceltaMago){
            case "Jaina":
            Console.WriteLine("hai scelto " + wizard1.name);
            magoScelto = wizard1;
            break;
            case "Medivh":
            Console.WriteLine("hai scelto " + wizard2.name);
            magoScelto = wizard2;
            break;
            default:
            Console.WriteLine("scegliere Jaina o Medivh");
            break;
            };
            if (sceltaMago == "Jaina" || sceltaMago == "Medivh"){
                Console.WriteLine("è apparso un " +  undead1.name +" cosa deve fare " + sceltaMago + "\n1." + magoScelto.spell + "\n2." + magoScelto.spell2 + "\n3." + magoScelto.spell3);
                while(vita > 0 && magoScelto.mana >=25 && undead1.Health >0){
                    var sceltaMagia = Convert.ToInt32(Console.ReadLine());
                    
                    switch(sceltaMagia){
                        case 1:
                        magoScelto.castSpell1();
                        undead1.Health -= magoScelto.damage;
                        break;
                        case 2:
                        magoScelto.castSpell2();
                        undead1.Health -= magoScelto.damage;
                        break;
                        case 3:
                        magoScelto.castSpell3();
                        break;
                        default:
                        Console.WriteLine("errore nella scelta della magia");
                        break;
        
                    }

                    

                    if (undead1.Health <= 0){
                        Console.WriteLine(undead1.name + " è morto" + "\nHai vinto la battaglia");
                        break;
                    }

                    if (undead1.Health >1){
                         Console.WriteLine(undead1.name +  " ha " + undead1.Health + " punti saluti\nOra cosa deve fare " + magoScelto.name + ":"+ "\n1." + magoScelto.spell + "\n2." + magoScelto.spell2 + "\n3." + magoScelto.spell3);
                    }
                    if (magoScelto.mana <25){
                        Console.WriteLine("il mio mana è insufficente , devo ricarlo\nLancia 1." +  magoScelto.spell3);

                        var ricaricaMana = Convert.ToInt32(Console.ReadLine());
                        switch(ricaricaMana){
                            case 1:
                            magoScelto.castSpell3();
                            Console.WriteLine("Ora " + magoScelto.name + " ha " + magoScelto.mana + " cosa deve fare:" + "\n1." + magoScelto.spell + "\n2." + magoScelto.spell2 + "\n3." + magoScelto.spell3);
                            break;
                        }
                    }

                }
                
        
        
           
        Console.ReadKey();
             
    }
    }

}

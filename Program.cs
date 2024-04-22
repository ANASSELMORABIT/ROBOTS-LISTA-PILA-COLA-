// Codifica un programa para el almacenamiento de robots.
// ● Genera 20 robots de manera aleatoria con las características de la práctica anterior, reutiliza la
// función de generación:
// ● Cuando los robots salen de la fábrica, no tienen nombre y hay que generar un nombre aleatorio
// en el formato de dos letras mayúsculas seguidas de tres dígitos, como RX837 o BC811, también
// tiene un modelo y pueden ser del tipo (R2D2, C3PO, BBB)
// ● Tenemos 3 nuevos almacenes, uno para cada modelo de robot, si el robot generado es del tipo
// R2D2 irá al almacén número 1 (LIST), si es C3PO irá al almacén número 2(STACK) y por último el
// BBB irá al almacén número 3(QUEUE).
// ● Los tres almacenes deben poder realizar las siguientes operaciones a través de un menú de
// usuario:
// - Mostrar todos o de cada uno de los almacenes a elección
// - Mostrar el último que ha entrado al cada almacén a elección
// - Mostrar el robot de una posición concreta de cada uno de los almacenes a elección.
// - Borrar todos los robots de cada almacén a elección o en total
// - Contar los robots de cada almacén
// ● Si necesitáis estructuras auxiliares podéis usar cualquiera de las 3 vistas en clase o incluso
// estructuras no dinámicas.
// *La implementación correcta de cada uno de los almacenes corresponde a ⅓ de la nota por
// almacén.
using System.Diagnostics;
using Microsoft.VisualBasic;

internal class Program
{
    
    static string[] Modelos= ["R2D2", "C3PO", "BBB"];
    private static void Main(string[] args)
    {
        List<Robot> R2D2 = new List<Robot>();
        Stack<Robot> C3PO = new Stack<Robot>();
        Queue<Robot> BBB = new Queue<Robot>();
        var rand = new Random();
        
        bool control = true;
        Console.WriteLine("**--------ANASS EL MORABIT--------**");

        Console.WriteLine("--------------BIENVENIDO AL PROGRAMA DE ALMACENAMIENTO DE ROBOTS--------------");
        while(control){
            switch (ShowMenu()){
            case 1:
                CrearAfterAllVerificacion(ref BBB,ref R2D2,ref C3PO,rand);
                break;
            case 2:
                Console.WriteLine("----------------Mostrar Todo los robots...----------------");
                ShowRobots(BBB,R2D2,C3PO);
                break;
            case 3:
                Console.WriteLine("----------------Mostrar un robot de  una posición concreta de cada uno de los almacénes a elección...----------------");
                MostrarRobotsEnPosicion( BBB,R2D2,C3PO);
                break;
            case 4:
                Console.WriteLine("----------------Mostrar el ultimo robot que ha entrado al cada almacén a elección...----------------");
                MostrarUltimoRobot(BBB,R2D2,C3PO);
                break;
            case 5:
                Console.WriteLine("----------------Eliminar un robot en una posicion de cada almacén a elección o en total...----------------");
                EliminarRobotInPosition(ref BBB,ref R2D2,ref C3PO);
                break;
            case 6:
                Console.WriteLine("----------------Borrar todos los robots de cada almacén a elección o en total...----------------");
                DeleteRobots(ref BBB,ref R2D2,ref C3PO);
                break;
            case 7:
            
                Console.WriteLine("----------------Contar los robots de cada almacén...----------------");
                contarRobots(BBB,R2D2,C3PO);
                break;
            case 8:
                Console.WriteLine("----------------Restablecer un robot en un almacén a elección...----------------");
                restablecerRobot(ref BBB,ref R2D2,ref C3PO,rand);
                break;
            case 9:
                Console.WriteLine("----------------Salir...----------------");
                control = false;
                break;
            default:
                Console.WriteLine("----------------Opción no válida----------------");
                break;
        }
        }
        
    }

   






















//-------------------Funciones-------------------


//-------------------Menu-------------------
    static int ShowMenu(){
        Console.WriteLine("----------------MENU PRINCIPAL----------------");
        Console.WriteLine("************************************************************************************************");
        Console.WriteLine("*---------1-Crear un robot  :");
        Console.WriteLine("*---------2-Mostrar los robots  de Todos o cada uno de los almacénes a elección:" );
        Console.WriteLine("*---------3-Mostrar un robot  de una posición concreta de uno de los almacenes a elección:");
        Console.WriteLine("*---------4-Mostrar el ultimo  robot que ha entrado al cada almacén a elección:");
        Console.WriteLine("*---------5-Eliminar  un robot de cada almacén a elección o en total:");
        Console.WriteLine("*---------6-Borrar todos los robots de cada almacén a elección o en total:");
        Console.WriteLine("*---------7-Contar los robots de cada almacén:");
        Console.WriteLine("*---------8-Restablecer un robot  de un almacén a elección:");
        Console.WriteLine("*---------9-Salir:");
        Console.WriteLine("************************************************************************************************");
        Console.WriteLine("*---------Ingresa una opcion:");
        int opcion = Convert.ToInt32(Console.ReadLine());
        return opcion;
    }
//---------------------Nombre y Modelo aleatorio para un robot---------------------
//---------------------------------------------------------------------------------
    //---------------------general un nombre aleatorio para un robot--------------------
    //Funcion de general un nombre aleatorio para un robot.
    static string generalNombreAleatorio(Random rand) //Funcion que nos ayuda a generar un nombre aleatorio
    {
            int randomNumber1 = rand.Next(0, 26); /*Este linaje genera un numero aleatorio entre 0 y 25,porque la funcion random acebta solo enteros*/
            int randomNumber2 = rand.Next(0, 26); /* En este parte de codigo aplicamos la formula para convertir el numero aleatorio a letra*/
            int numero1=rand.Next(0, 10);
            int numero2=rand.Next(0, 10);
            int numero3 = rand.Next(0, 10);
            char letraAleatoria1 = (char)('A' + randomNumber1);
            char letraAleatoria2 = (char)('A' + randomNumber2);
            string nombreRobot = $"{letraAleatoria1}{letraAleatoria2}{numero1}{numero2}{numero3}";
            return nombreRobot;
    }
    //------------------general un modelos Aleatario para un robot------------------
    //Funcion de general un Modelo Aleatario para un robot
    static string generalModeloAleatorio(Random rand){
        int randomNumber = rand.Next(0, Modelos.Length);
        string modelo = Modelos[randomNumber];
        return modelo;
    }
//-----------------crear un robot-----------------
//Funcion de crear un robot
    static void AnadirRobotAlmacen(ref Queue<Robot> BBB,ref List<Robot> R2D2,Stack<Robot> C3PO,Random rand){
        Robot robotNuevo;
        robotNuevo.modelo=generalModeloAleatorio(rand);
        robotNuevo.nombre=verificarNombreNoExiste(ref BBB,ref R2D2,ref C3PO,rand,robotNuevo.modelo);
        switch(robotNuevo.modelo){
            case "R2D2":    
                            R2D2.Add(robotNuevo);
                            break;
            case "C3PO":    
                            C3PO.Push(robotNuevo);
                            break;
            default:     
                            BBB.Enqueue(robotNuevo);
                            break;
        }
        Console.WriteLine("Se ha creado el robot para el almacen {0} con el nombre {1}",robotNuevo.modelo,robotNuevo.nombre);
    }
    //----------------------------------------------------------------------
    //Funcion de Verificar si el nombre aleatoeio exite en uno de los almacenes.
    static string verificarNombreNoExiste(ref Queue<Robot> BBB,ref List<Robot> R2D2,ref Stack<Robot> C3PO,Random rand,string modelo) {
       bool nombreexiste=true;
       bool test=false;
       string nombreRobot=generalNombreAleatorio(rand);
       while(nombreexiste){
            switch(modelo){
                case "R2D2":    foreach(Robot robot in R2D2){
                                    if(robot.nombre==nombreRobot){
                                        test=true;
                                        nombreRobot=generalNombreAleatorio(rand);
                                        break;
                                    }
                                }
                                break;
                case "C3PO":    foreach(Robot robot in C3PO){
                                    if(robot.nombre==nombreRobot){
                                        test=true;
                                        nombreRobot=generalNombreAleatorio(rand);
                                        break;
                                    }
                                }
                                break;
                default:       foreach(Robot robot in BBB){
                                    if(robot.nombre==nombreRobot){
                                        test=true;
                                        nombreRobot=generalNombreAleatorio(rand);
                                        break;
                                    }
                                }
                                break;
                }
            if (test==false){
                nombreexiste=false;
            }
            
        }
        return nombreRobot;
    }
    // Verificar el total de robots creados
    static void CrearAfterAllVerificacion(ref Queue<Robot> BBB,ref List<Robot> R2D2,ref Stack<Robot> C3PO,Random rand){
        int totalRobots;
        totalRobots=R2D2.Count+C3PO.Count+BBB.Count;
        if(totalRobots<20){
            Console.WriteLine("Creando robots ...");
            AnadirRobotAlmacen(ref BBB,ref R2D2,C3PO,rand);
        }
        else{
            Console.WriteLine("No se pueden crear mas robots ");
        }
    }
           

    
    //----------------------------------Mostrar----------------------------
    //-----------------------Mostrar los Robots de Todos o cada uno de los almacenes-------------------
    //Mostrar Todos de los almacenes
    static void MostrarRobots(Queue<Robot> BBB, List<Robot> R2D2, Stack<Robot> C3PO)
    {
        
        Console.WriteLine("");
        Console.WriteLine("---------------------------");
        foreach (string modelo in Modelos)
        {
            Console.WriteLine("---------------------------");   
            switch (modelo){
                            case "R2D2":    MostrarAlmacenR2D2(R2D2);
                                break;
                            case "C3PO":    MostrarAlmacenC3P0(C3PO);
                                break;
                            default:       MostrarAlmacenBBB(BBB);
                                break;
            }
        }
    }
  
    
    
    //Mostrar Los Robots del Almacen R2D2
    static void MostrarAlmacenR2D2(List<Robot> R2D2){
        Console.WriteLine("Mostrar los Robots del Almacen R2D2");
        Console.WriteLine("---------------------------");
        foreach(Robot robot in R2D2){
            Console.WriteLine("-----------------------");

            Console.WriteLine("Nombre: "+robot.nombre);

            Console.WriteLine("Modelo: "+robot.modelo);

        }
    }
    //Mostrar Los Robots del Almacen C3PO
    static void MostrarAlmacenC3P0(Stack<Robot> C3PO){
        Stack<Robot> HelperStack = new Stack<Robot>(); //este stack es para poder mostrar los robots en orden inverso, 
                                                        //porque el stack no tiene un metodo para mostrar en orden inverso,y para mostrar los robots en forma ordenada
                                                       
        foreach(Robot robot in C3PO){
            HelperStack.Push(robot);
        }
        Console.WriteLine("Mostrar los Robots del Almacen C3PO");
        Console.WriteLine("---------------------------");
        foreach (Robot robot in HelperStack){
            Console.WriteLine("-----------------------");
            Console.WriteLine("Nombre: "+robot.nombre);
            
            Console.WriteLine("Modelo: "+robot.modelo);

        }
    }
    //Mostrar Los Robots del Almacen BBB
    static void MostrarAlmacenBBB(Queue<Robot> BBB){
        Console.WriteLine("Mostrar los Robots  del Almacen BBB");
        Console.WriteLine("---------------------------");
        foreach (Robot robot in BBB){
            Console.WriteLine("-----------------------");
            Console.WriteLine("Nombre: "+robot.nombre);

            Console.WriteLine("Modelo: "+robot.modelo);

        
        }
    }
    static void MostrarRobotsEnEleccion(Queue<Robot> BBB, List<Robot> R2D2, Stack<Robot> C3PO ){
        string modelo;
       
        modelo=preguntaPorAccionAlmacen("ver");
        switch (modelo){
            case "R2D2":    MostrarAlmacenR2D2(R2D2);
                break;
            case "C3PO":    MostrarAlmacenC3P0(C3PO);
                break;
            default:       MostrarAlmacenBBB(BBB);
                break;
        }
    }
      //Este es la funcion que voy a usar para mostrar los robots de cada uno de los almacenes o de todos los almacenes
    static void ShowRobots(Queue<Robot> BBB, List<Robot> R2D2, Stack<Robot> C3PO){
        int opcionEligeda;
        Console.WriteLine("Mostrar los robots de Todos  los almacénes o de uno de los almacénes a elección...");
        do{
            Console.WriteLine("1-Mostrar los robots de Todos  los almacénes .\n2-Mostrar los robots de  uno de los almacénes a elección" );
            opcionEligeda = Convert.ToInt32(Console.ReadLine());
        }while (opcionEligeda!= 1 && opcionEligeda!= 2);
        if (opcionEligeda == 1){
            MostrarRobots(BBB,R2D2,C3PO);
        }
        else{
            MostrarRobotsEnEleccion( BBB,R2D2,C3PO);
        }
    }
    //mostrar los robots en una posicion especifica de un almacén
     //EL almacen R2D2
    static void MostrarRobotsEnPosicionR2D2(List<Robot> R2D2){
        int posicion;
        Console.WriteLine("El almacen R2D2");
        Console.WriteLine("---------------------------");
        
        posicion=preguntaPorAccionPosicion("ver",R2D2.Count);
        for (int i=0;i<R2D2.Count;i++){
            if(i==posicion){
                    Console.WriteLine("El robot  que quieres ver es: ");
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Nombre: "+R2D2[i].nombre);
                    Console.WriteLine("Modelo: "+R2D2[i].modelo);
                    
                    break;
            }
        }
        
    }
    //EL almacen C3PO
    static void MostrarRobotsEnPosicionC3P0(Stack<Robot> C3PO){
        int posicion;
        Console.WriteLine("El almacen C3PO");
        Console.WriteLine("---------------------------");
        
        posicion=preguntaPorAccionPosicion("ver",C3PO.Count);
        int contadorMostrar=0;
        foreach (Robot robot in C3PO){
            if(contadorMostrar==C3PO.Count-posicion-1){
                    Console.WriteLine("El robot  que quieres ver es: ");
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Nombre: "+robot.nombre);
                    Console.WriteLine("Modelo: "+robot.modelo);

                    break;
            }
            contadorMostrar++;
        }
    }
    //EL almacen BBB
    static void MostrarRobotsEnPosicionBBB(Queue<Robot> BBB){
        int posicion;
        Console.WriteLine("El almacen BBB");
        Console.WriteLine("---------------------------");
        
        posicion=preguntaPorAccionPosicion("ver",BBB.Count);
        int contadorMostrar=0;
        foreach (Robot robot in BBB){
            if(contadorMostrar==posicion){
                    Console.WriteLine("El robot  que quieres ver es: ");
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Nombre: "+robot.nombre);
                    Console.WriteLine("Modelo: "+robot.modelo);
                    break;
            }
            contadorMostrar++;
        }
    }
    
    static void MostrarRobotsEnPosicion(Queue<Robot> BBB, List<Robot> R2D2, Stack<Robot> C3PO) {
        
        string modelo;
        
        modelo=preguntaPorAccionAlmacen("ver");
        switch (modelo){
            case "R2D2":    if (R2D2.Count==0){
                                Console.WriteLine("No hay robots en el almacen R2D2");
                                
                            }
                            else{
                                MostrarRobotsEnPosicionR2D2(R2D2);
                            }
                            
                            break;
                            
            case "C3PO":    if (C3PO.Count==0){
                                Console.WriteLine("No hay robots en el almacen C3PO");
                            }
                            else{
                                MostrarRobotsEnPosicionC3P0(C3PO);
                            }
                            
                            break;
            default:       if (BBB.Count==0){
                                Console.WriteLine("No hay robots en el almacen BBB");
                            }
                            else{
                                MostrarRobotsEnPosicionBBB(BBB);
                            }
                            
                            break;
            
        }
        
    }
    //Mostrar el ultimo robot que ha entrado al almacen
    static void MostrarUltimoRobot(Queue<Robot> BBB, List<Robot> R2D2, Stack<Robot> C3PO) {
        string modelo;
        
        modelo=preguntaPorAccionAlmacen("ver");
        switch (modelo){
            case "R2D2":    Console.WriteLine("El ultimo robot  que ha entrado al almacen R2D2 es: ");
                            Console.WriteLine("Nombre: "+R2D2[R2D2.Count-1].nombre);
                            Console.WriteLine("Modelo: "+R2D2[R2D2.Count-1].modelo);
                            
                            break;
            case "C3PO":    Console.WriteLine("El ultimo robot  que ha entrado al almacen C3PO es: ");
                            Console.WriteLine("Nombre: "+C3PO.Peek().nombre);
                            Console.WriteLine("Modelo: "+C3PO.Peek().modelo);
                            
                            break;
            default :     Console.WriteLine("El ultimo robot  que ha entrado al almacen BBB es: ");
                            int posicion=0;
                            foreach(Robot robot in BBB){
                                if(posicion==BBB.Count-1){

                                    Console.WriteLine("Nombre: "+robot.nombre);
                                    Console.WriteLine("Modelo: "+robot.modelo);
                                    
                                    break;
                                }
                                posicion++;
                            }
                            break;
        }
    }
//-------------------------------------Eliminar y borrar ---------------------------
    //Eliminar un robot de un almacen (R2D2, C3PO, BBB)
    static void EliminarRobotAlmacenPosicion(ref Queue<Robot> BBB, ref List<Robot> R2D2, ref Stack<Robot> C3PO) {
        string modelo;
        int posicion;
        
        modelo=preguntaPorAccionAlmacen("borrar");
        switch (modelo){
            case "R2D2":    Console.WriteLine("El almacen R2D2");
                            Console.WriteLine("---------------------------");
                            if (R2D2.Count==0){
                                Console.WriteLine("No hay robots en el almacen R2D2");
                            }
                            else{
                                posicion=preguntaPorAccionPosicion("borrar",R2D2.Count);
                                EliminarRobotR2D2(ref R2D2, posicion);
                            }
                            
                            break;
            case "C3PO":    Console.WriteLine("El almacen C3PO");
                            Console.WriteLine("---------------------------");
                            if (C3PO.Count==0){
                                Console.WriteLine("No hay robots en el almacen C3PO");
                            }
                            else{
                                posicion=preguntaPorAccionPosicion("borrar",C3PO.Count);
                                EliminarRobotC3PO(ref C3PO, posicion);
                            }
                          
                            break;
                            
            default :     Console.WriteLine("El almacen BBB");
                          Console.WriteLine("---------------------------");
                          if (BBB.Count==0){
                              Console.WriteLine("No hay robots en el almacen BBB");
                          }
                          else{
                              posicion=preguntaPorAccionPosicion("borrar",BBB.Count);
                              EliminarRobotBBB(ref BBB, posicion);
                          }
                          
                           break;
        }
    }
    //Eliminar un robot de R2D2
    static void EliminarRobotR2D2(ref List<Robot> R2D2, int posicion)
    {
        
        R2D2.RemoveAt(posicion);
        Console.WriteLine("El robot  ha sido eliminado del almacen R2D2(la lista se reordeno)... ");
        
        
    }
    //Eliminar un robot de C3PO
    static void EliminarRobotC3PO(ref Stack<Robot> C3PO,int posicion) {
        
        Stack<Robot> Helper = new Stack<Robot>();
        int i=0;
        
        foreach(Robot robot in C3PO){
            if(i!=C3PO.Count-1-posicion){

                Helper.Push(robot);
            }
            i++;
        }
        C3PO.Clear();
        Console.WriteLine("El robot  ha sido eliminado del almacen C3PO(la pila se reordeno)... ");
        while(Helper.Count>0){
            C3PO.Push(Helper.Pop());
        }
        

        
        
    }
    //Eliminar un robot de BBB
    static void EliminarRobotBBB(ref Queue<Robot> BBB,int posicion) {
        Queue<Robot> Helper=new Queue<Robot>();
        int i=0;
        
        foreach(Robot robot in BBB){
            if (i!=posicion){
                Helper.Enqueue(robot);
            }
            i++;
        }
        Console.WriteLine("El robot  ha sido eliminado del almacen BBB(la cola se reordeno)... ");
        BBB=Helper;
    }
    //Eliminar un robot de todo los almacenes en una posicion
    static void EliminarRobotPosicion(ref Queue<Robot> BBB, ref List<Robot> R2D2,ref Stack<Robot> C3PO) {
        int posicion;
        do{
                Console.WriteLine("ingresa la posicion del robot  que quieres eliminar:(ingresa una posicion valida)");
                posicion = Convert.ToInt32(Console.ReadLine());
        }while (posicion<0 || posicion>R2D2.Count-1 || posicion>C3PO.Count-1 || posicion>BBB.Count-1 );
        
        EliminarRobotR2D2(ref R2D2, posicion);
        EliminarRobotC3PO(ref C3PO, posicion);
        EliminarRobotBBB(ref BBB, posicion);
    }
    //Este funcion es lo que pide el usuario para borrar un robot de una posicion
    static void EliminarRobotInPosition(ref Queue<Robot> BBB, ref List<Robot> R2D2,ref Stack<Robot> C3PO){
        int opcionEligeda;
        do{
            Console.WriteLine("1-Eliminar un robot en una posicion de un almacén a elección.\n2-Eliminar un robot en una posicion de todos los almacenes" );
            opcionEligeda = Convert.ToInt32(Console.ReadLine());
        }while (opcionEligeda!= 1 && opcionEligeda!= 2);
        if (opcionEligeda == 1){
            EliminarRobotAlmacenPosicion(ref BBB,ref R2D2,ref C3PO);
        }
        else{
            if(R2D2.Count==0 || C3PO.Count==0 || BBB.Count==0){
                Console.WriteLine("No puedes borrar un robot de todos los almacenes (no hay robots en uno de los almacenes)");
            }
            else{
                EliminarRobotPosicion(ref BBB,ref R2D2,ref C3PO);
            }
            
        }
    }

    //Borrar Todo los robots de un almacen (R2D2, C3PO, BBB)
       //Borrar todo los robots de R2D2
       static void BorrarTodoRobotsR2D2(ref List<Robot> R2D2) {
        Console.WriteLine("El almacen R2D2");
        Console.WriteLine("---------------------------");
        Console.WriteLine("Se van a borrar todos los robots del almacen R2D2 ...");
        R2D2.Clear();
        Console.WriteLine("Todos los robots del almacen R2D2 han sido borrados");
        Console.WriteLine("---------------------------");
       }
       //Borrar todo los robots de C3PO
       static void BorrarTodoRobotsC3PO(ref Stack<Robot> C3PO) {
        Console.WriteLine("El almacen C3PO");
        Console.WriteLine("---------------------------");
        Console.WriteLine("Se van a borrar todos los robots del almacen C3PO ...");
        C3PO.Clear();
        Console.WriteLine("Todos los robots del almacen C3PO han sido borrados");
        Console.WriteLine("---------------------------");
       }
       //Borrar todo los robots de BBB
       static void BorrarTodoRobotsBBB(ref Queue<Robot> BBB) {
        Console.WriteLine("El almacen BBB");
        Console.WriteLine("---------------------------");
        Console.WriteLine("Se van a borrar todos los robots del almacen BBB ...");
        BBB.Clear();
        Console.WriteLine("Todos los robots del almacen BBB han sido borrados");
        Console.WriteLine("---------------------------");
       }
       //Borrar todo los robots de todos los almacenes
       static void BorrarTodoRobots(ref Queue<Robot> BBB, ref List<Robot> R2D2, ref Stack<Robot> C3PO) {
        BorrarTodoRobotsR2D2(ref R2D2);
        BorrarTodoRobotsC3PO(ref C3PO);
        BorrarTodoRobotsBBB(ref BBB);
        Console.WriteLine("Todos los robots han sido borrados");
       }
       //Borrar un robot de un almacen (R2D2, C3PO, BBB)
       static void BorrarRobotsAlmacen( ref Queue<Robot> BBB, ref List<Robot> R2D2,ref  Stack<Robot> C3PO) {
        string Almacen;
            
            Almacen=preguntaPorAccionAlmacen("borrar");
            switch(Almacen) {
                case "R2D2": BorrarTodoRobotsR2D2(ref R2D2);
                            break;
                case "C3PO": BorrarTodoRobotsC3PO(ref C3PO);
                            break;
                default: BorrarTodoRobotsBBB(ref BBB);
                            break;
                
            }
        }
        static void DeleteRobots( ref Queue<Robot> BBB, ref List<Robot> R2D2,ref  Stack<Robot> C3PO) {
            int opcionEligeda;
            do{
                    Console.WriteLine("1-Borrar todos los robots de un almacén a elección.\n2-Borrar todos los robots de todos los almacenes" );
                    opcionEligeda = Convert.ToInt32(Console.ReadLine());
            }while (opcionEligeda!= 1 && opcionEligeda!= 2);
            if (opcionEligeda == 1){
                    BorrarRobotsAlmacen(ref BBB,ref R2D2,ref C3PO);
            }
            else{
                    BorrarTodoRobots(ref BBB,ref R2D2,ref C3PO);
            }
        }
        //Contar los robots de un almacen (R2D2, C3PO, BBB)
    static void contarRobots(Queue<Robot> BBB, List<Robot> R2D2, Stack<Robot> C3PO)
    {
        string Almacen;
        
        Almacen=preguntaPorAccionAlmacen("contar");
        switch (Almacen)
        {
            case "R2D2": Console.WriteLine("El almacen R2D2 cuenta con {0} robots",R2D2.Count);
                        break;
            case "C3PO": Console.WriteLine("El almacen C3PO cuenta con {0} robots",C3PO.Count);
                        break;
            default: Console.WriteLine("El almacen BBB cuenta con {0} robots",BBB.Count);
                        break;
        }
    }
    //Restablecer un robot en una posicion de un almacen (R2D2, C3PO, BBB)

    //Restablecer un robot en R2D2
    static void restablecerRobot(ref Queue<Robot> BBB, ref List<Robot> R2D2, ref Stack<Robot> C3PO, Random rand)
    {
        int posicion;
        string Almacen;
       
        Almacen=preguntaPorAccionAlmacen("restablecer");
        switch (Almacen)
        {
            case "R2D2":
                if (R2D2.Count==0){
                    Console.WriteLine("No hay robots en el almacen R2D2");
                    break;
                }
                posicion=preguntaPorAccionPosicion("restablecer",R2D2.Count);
                for (int i = 0; i < R2D2.Count; i++)
                {
                    if (i== posicion)
                    {
                        Robot helper = R2D2[i];
                        helper.nombre = verificarNombreNoExiste(ref BBB, ref R2D2, ref C3PO, rand, Almacen);
                        Console.WriteLine("El robot ha sido restablecido en la posicion {0}", posicion," y su nuevo nombre es {0}", helper.nombre);
                        R2D2[i] = helper;
                        break;
                    }
                }
                
                break;
            case "C3PO":
                if (C3PO.Count==0){
                    Console.WriteLine("No hay robots en el almacen C3PO"); break;
                }
                posicion=preguntaPorAccionPosicion("restablecer",C3PO.Count);
                Stack<Robot> HelperRestablecerC3PO=new Stack<Robot>();
                int contadorC3PO=0;
                foreach (Robot robot in C3PO){
                    if(contadorC3PO!=C3PO.Count-1-posicion){
                        HelperRestablecerC3PO.Push(robot);
                    }
                    else{
                        Robot helper2;
                        helper2=robot;
                        helper2.nombre=verificarNombreNoExiste(ref BBB,ref R2D2,ref C3PO,rand,Almacen);
                        HelperRestablecerC3PO.Push(helper2);

                    }
                    contadorC3PO++;
                }
                C3PO.Clear();
                while(HelperRestablecerC3PO.Count>0){
                    C3PO.Push(HelperRestablecerC3PO.Pop());
                }
                Console.WriteLine("el robot ha sido restablecido en la posicion {0}", posicion,"(Los posiciones del almacen se reordenan)");
                break;
            default:
               if (BBB.Count==0){
                   Console.WriteLine("No hay robots en el almacen BBB"); break;
               }
                posicion=preguntaPorAccionPosicion("restablecer",BBB.Count);
                int contadorBBB=0;
                Queue<Robot> HelperRestablecerBBB=new Queue<Robot>();
                foreach(Robot robot in BBB){
                    if(contadorBBB!=posicion){
                        HelperRestablecerBBB.Enqueue(robot);
                    }
                    else{
                        Robot helper3;
                        helper3=robot;
                        helper3.nombre=verificarNombreNoExiste(ref BBB,ref R2D2,ref C3PO,rand,"BBB");
                        HelperRestablecerBBB.Enqueue(helper3);
                    }
                    contadorBBB++;
                }
                BBB.Clear();
                while(HelperRestablecerBBB.Count>0){
                    BBB.Enqueue(HelperRestablecerBBB.Dequeue());
                }
                Console.WriteLine("el robot ha sido restablecido en la posicion {0}", posicion,"(Los posiciones del almacen se reordenan)");
                break;
        }
    }
//-------------------Funciones de preguntar--------------------
static int preguntaPorAccionPosicion(string accion,int count){
    int posicion;
    do{
        Console.WriteLine("ingresa la posicion del robot que quieres {0}:(ingresa una posicion valida)[entre 0 y {1}]",accion,count-1);
        posicion = Convert.ToInt32(Console.ReadLine());
    }while( posicion<0 || posicion>count-1);   
    return posicion;
}
static string preguntaPorAccionAlmacen(string accion){
    string Almacen;
    do
    {
        Console.WriteLine("ingresa el nombre del almacen del robot que quieres {0} [R2D2, C3PO, BBB]:(ingresa un almacen valido)",accion);
        Almacen = Console.ReadLine();
    } while (Almacen != "R2D2" && Almacen != "C3PO" && Almacen != "BBB");
    return Almacen;
}

//-------------------El struct de Robots-------------------

         public struct Robot
    {
        public string nombre;
        public string modelo;
        
    }
}

    
    
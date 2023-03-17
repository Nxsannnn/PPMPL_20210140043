using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularQueues
{
    /// <summary>
    /// main class
    /// </summary>
    class Program
    {
        int FRONT, REAR, max = 5;
        int[] queue_array = new int[5];

        public Program()
            
        {
            FRONT = -1;
            REAR = -1;
        }
        public void insert(int element)
        {
            ///<summary>
            ///Pernyataan ini memeriksa kondisi luapan.
            ///</summary>
            if ((FRONT == 0 && REAR == max - 1) || (FRONT == REAR + 1))
            {
                Console.WriteLine("\nQueue overflow\n");
                return;
            }
            ///<summary>
            ///Pernyataan berikut ini memeriksa apakah antrian kosong. Jika antrian kosong, maka nilai variabel REAR dan FRONT diset menjadi 0
            ///</summary>
            if (FRONT == -1)
            {
                FRONT = 0;
                REAR = 0;
            }
            else
            {
                ///<summary>
                ///Jika REAR berada di posisi terakhir dari array, maka nilai REAR diatur ke 0 yang sesuai dengan posisi pertama dari array.
                ///</summary>
                if (REAR == max - 1)
                    REAR = 0;
                else
                    ///<summary>
                    ///Jika REAR tidak berada di posisi terakhir, maka nilainya bertambah satu.
                    ///</summary>
                    REAR = REAR + 1;
            }
            ///<summary>
            ///Setelah posisi REAR ditentukan, elemen ditambahkan di tempat yang semestinya.
            ///</summary>
            queue_array[REAR] = element;
        }
        public void remove()
        {
            ///<summary>
            ///Memeriksa apakah antrian kosong.
            ///</summary>
            if (FRONT == -1)
            {
                Console.WriteLine("Queue underflow\n");
                return;
            }
            Console.WriteLine("\nThe Element deleted from the queue is: " + queue_array[FRONT]
                + "\n");
            ///<summary>
            ///Periksa apakah antrian memiliki satu elemen.
            ///</summary>
            if (FRONT == REAR)
            {
                FRONT = -1;
                REAR = -1;
            }
            else
            {
                ///<summary>
                ///Jika elemen yang akan dihapus berada pada posisi terakhir dari array, maka nilai FRONT diset ke 0 yaitu elemen pertama dari array.
                ///</summary>
                if (FRONT == max - 1)
                    FRONT = 0;
                else
                    ///<summary>
                    ///FRONT bertambah satu jika itu bukan elemen pertama dari array.
                    ///</summary>
                    FRONT = FRONT + 1;

            }
        }
        public void display()
        {
            int FRONT_position = FRONT;
            int REAR_position = REAR;
            ///<summary>
            ///Memeriksa apakah antrian kosong.
            ///</summary>
            if (FRONT == -1)
            {
                Console.WriteLine("Queue is empty\n");
                return;
            }
            Console.WriteLine("\nElements in the queue are ...................\n");
            if (FRONT_position <= REAR_position)
            {
                ///<summary>
                ///melintasi antrian hingga elemen terakhir yang ada dalam array.
                ///</summary>
                while (FRONT_position <= REAR_position)
                {
                    Console.Write(queue_array[FRONT_position] + "   ");
                    FRONT_position++;
                }
                Console.WriteLine();
            }
            else
            {
                ///<summary>
                ///melintasi antrian sampai posisi terakhir dari array
                ///</summary>
                while (FRONT_position <= max - 1)
                {
                    Console.Write(queue_array[FRONT_position] + "     ");
                    FRONT_position++;
                }
                ///<summary>
                ///atur posisi FRONT ke elemen pertama array.
                ///</summary>
                FRONT_position = 0;
                ///<summary>
                ///melintasi array hingga elemen terakhir yang ada dalam antrian.
                ///</summary>
                while (FRONT_position <= REAR_position)
                {
                    Console.Write(queue_array[FRONT_position] + "     ");
                    FRONT_position++;
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Program queue = new Program();
            char ch;
            while (true)
            {
                try
                {

                    Console.WriteLine("Menu");
                    Console.WriteLine("1. Menyimpan data buku");
                    Console.WriteLine("2. Menghapus dsta buku");
                    Console.WriteLine("3. Tampilkan hasil");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nEnter your choice (1-4):  ");
                    ch = Convert.ToChar(Console.ReadLine());
                    Console.WriteLine();
                    switch (ch)
                    {
                        case '1':
                            {
                                Console.Write("Enter a number:  ");
                                int num = Convert.ToInt32(System.Console.ReadLine());
                                Console.WriteLine();
                                queue.insert(num);
                            }
                            break;
                        case '2':
                            {
                                queue.remove();
                            }
                            break;
                        case '3':
                            {
                                queue.display();
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid option !!");
                            }
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Check for the values entered.");
                }

            }
        }
    }
}

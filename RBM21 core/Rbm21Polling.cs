using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.IO.Ports;

using System.Diagnostics;

namespace RBM21_core
{
    class Rbm21Polling
    {
        const string pathImpianto = "";
        SerialPort sp = null;
        public Rbm21Polling(string port)
        {
            Debug.Indent();
            Debug.WriteLine("Executing RBM21Polling's constructor");
                      
            sp = new SerialPort(port, 19200, Parity.None, 8, StopBits.One);
            sp.Open();
            // sp.ReceivedBytesThreshold = 14;
            //sp.Open();//is it safe to open the port only here? no! FIXME! control when it close!
        }
        
        /*
        System.Windows.Forms.Timer maxTimeTimer = new System.Windows.Forms.Timer();
        public bool CheckConnection()
        {
            
            SerialPort sp = null;           
            
            maxTimeTimer.Tick += new EventHandler(maxTimeEventProcessor);
            maxTimeTimer.Interval = 5000;

            sp = new SerialPort("COM2", 19200, Parity.None, 8, StopBits.One);
            sp.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            sp.Open();
            Byte[] request = new Byte[] { 0x46, 0x72 };

            maxTimeTimer.Start();
            sp.Write(request, 0, request.Length);
            
            
            sp.Close();
            return true;
        }
        public bool CheckConnection1()
        {
            SerialPort sp = null;

                maxTimeTimer.Tick += new EventHandler(maxTimeEventProcessor);
                maxTimeTimer.Interval = 5000;

                    sp = new SerialPort("COM2", 19200, Parity.None, 8, StopBits.One);
                sp.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                sp.Open();
                    Byte[] request = new Byte[] { 0x46, 0x72 };

                     maxTimeTimer.Start();
                    sp.Write(request, 0, request.Length);
                    Byte[] buf = new Byte[20];
                    int readed = 0;
                  
                    while (readed <= 0)
                    {
                        //when it read some bytes, they will be stored in the appropriate position of buf
                        readed += sp.Read(buf, readed, 10);
                    }

            Console.WriteLine("Siii, va tutto beneeeee");
                    maxTimeTimer.Stop();
                    sp.Close();
                    return true;
        }
private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("Siii, va tutto beneeeee");
            maxTimeTimer.Stop();
        }
        private void maxTimeEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            Debug.WriteLine("è passato troppo tempo, che il disp sia scollegato?");
        }
        */

        // store the response (a 14byte array) in a User class          
        public User HexToUser(byte[] response)
        {
            /*
             *  Example of response: 59 01 10 06 00 F1 6F E0 00 00 04 6A 0C 00 
             *                index:  0  1  2  3  4  5  6  7  8  9 10 11 12 13   
             *                
             */
            User usr = new User();                
            usr.CreditoResiduo = (int) response[9];
            
            int day = (int) response[12];
            int minutes = (int) response[10] * 16 * 16 + (int)response[11];
            usr.Time = FileReader.timeCalculator(day, minutes);
            usr.Key = response[3].ToString("X2") + response[4].ToString("X2") + response[5].ToString("X2") + response[6].ToString("X2") + response[7].ToString("X2");
            //usr.UserCode = usr.Key; //FIXME
            
            return usr;
        }
        /*
         * Ask RBM21 about a single user.
         * Command to read user data is: 0x46, 0x6D, b1, b0 (for example for user 4, command is 0x46, 0x6D, 0x0, 0x05  
         * 
         * RBM21 response is 14 bytes. unfortunately using the classical DataReceived event make the code more complex
         * (sometimes 3 events are generated = 3 calls to a simple method to manage the buffer) so i decided to use
         * the old polling.
         * 
         * If User does not exist, RBM21 will return 00 00 00 00 00 00 00 00 00 00 00 00 11 00
         * so this condition is easy to catch (Key== "0000000000")
         */
        public User GetRBM21UserData(Int32 userIndex)
        {
            // 0<userIndex<500; we need only the last 2 bytes of that variable.
            byte b0 = (byte)userIndex,
                 b1 = (byte)(userIndex >> 8);            
            
            Byte[] request = new Byte[] { 0x46, 0x6D, b1, b0 };
            Debug.WriteLine("P: " + ByteArrayToString(request));
            sp.Write(request, 0, request.Length);

            const int ResponseLength = 14;
            Byte[] buf = new Byte[ResponseLength];
            int readed = 0;
            /* since sp.Read will read only the available data (and we can never be sure, sometimes 1 byte, sometimes 4 bytes, other times 7..)
             * i have to itereate the read method until all response data (14 bytes) are returned.
             */
            while (readed < ResponseLength) {
                //when it read some bytes, they will be stored in the appropriate position of buf
                readed += sp.Read(buf, readed, ResponseLength-readed);                
            }

            Debug.WriteLine("R: {0}", ByteArrayToString(buf));

            return HexToUser(buf);            
        }

        //return list with all users(only users with an associated key) in RBM21
        public List<User> ReadAllUsers()
        {
            //to measure execution time, Stopwatch is a must-use! (have been for this purpose)
            Stopwatch sw = Stopwatch.StartNew();

            List<User> usersList = new List<User>();
            int i = 0;
            do
            {
                User u = GetRBM21UserData(i);
                //if user does not exists, rbm21 return 00 00 00 00 00 00 00 00 00 00 00 00 11 00, so this manage that case
                if (u.Key == "0000000000")
                    break;
                usersList.Add(u);
                i++;
            } while (true);

            sw.Stop();
            Debug.WriteLine("Time taken: {0}s", sw.Elapsed.TotalMilliseconds / 1000);

            return usersList;            
        }


        public string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2 + ba.Length * 2 - 1);
            foreach (byte b in ba)
                hex.AppendFormat("{0:X2} ", b);
            return hex.ToString();
        }

        public void Close()
        {
            sp.Close();
        }
    }
}





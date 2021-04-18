﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TicTacToeTests")]

namespace TicTacToe
{
    static class Program
    {

        private const Player InitialPlayer = Player.PlayerNull;
        public static Random Random { get; set; }

        /// <summary>
        /// The main entry got the application
        /// </summary>
        static void Main()
        {
            Program.Random = new Random();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // create window
            GameForm gameWindow = new GameForm();
            gameWindow.SetStartPlayer(Program.InitialPlayer);

            Debug.WriteLine("Start app.");

            Game newGame = new Game(gameWindow);
            newGame.StartGame();
            gameWindow.StartGame(newGame);

            // show form
            Application.Run(gameWindow);
        }

        /// <summary>
        /// Helper function, thanks https://stackoverflow.com/a/4135491
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        internal static string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        /// <summary>
        /// replace the last occurence of a string, thanks https://stackoverflow.com/a/14826068
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Find"></param>
        /// <param name="Replace"></param>
        /// <returns></returns>
        internal static string ReplaceLastOccurrence(string Source, string Find, string Replace)
        {
            int place = Source.LastIndexOf(Find);

            if (place == -1)
                return Source;

            string result = Source.Remove(place, Find.Length).Insert(place, Replace);
            return result;
        }

        /// <summary>
        /// Converts a memory stream to a cursor file. This is needed for the conversion of the file resource 
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        internal static Cursor ConvertCursor(byte[] buffer)
        {
            using (var m = new MemoryStream(buffer))
            {
                return new Cursor(m);
            }
        }
    }
}

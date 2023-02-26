using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WordBank.Models;

namespace WordBank.DataAccess
{
        /// <summary>
        /// Сохранение данных
        /// </summary>
        public class WordBankBaseContext : DbContext
        {
            public DbSet<Word> Words { get; set; }
            
            public WordBankBaseContext()
            {
                Database.EnsureCreated();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="options"></param>
            protected override void OnConfiguring(DbContextOptionsBuilder options)
            {
                string dbFileName = "WordBankData.db";
                #if ANDROID
                var dbPath = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DataDirectory.Name).Path;
                #else
                var dbPath = FileSystem.AppDataDirectory;
                #endif
                dbFileName = Path.Combine(dbPath, dbFileName);
                options.UseSqlite($"Filename={dbFileName}");
                base.OnConfiguring(options);
            }
        }
        
        public class DbWords
        {
            public int DbWordsId { get; set; }
            public string WordId { get; set; }
            public string WordName { get; set; }
            public string Description { get; set; }
            public string Translation { get; set; }
            public string Sample { get; set; }
            public string Time { get; set; }
        }
        }

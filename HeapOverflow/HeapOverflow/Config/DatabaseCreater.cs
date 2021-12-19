using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeapOverflow.Config
{
	public class DatabaseCreater
	{
		private static readonly Logger _log = new Logger("DatabaseCreater");

		public static Connection Connection { get; set; }

		public static void CreateDatabase()
		{
			string query = String.Format("CREATE DATABASE IF NOT EXISTS {0}", Connection.Database);
			RunCreateQuery(query, true);

			CreateTables();
		}

		private static void CreateTables()
		{
			CreateAdminTable();
			CreateUsersTable();
			CreateRoleTable();
			CreateUserLoginTable();
			CreatePostTable();
			CreateCommentTable();
			CreateVoteTable();
		}

		private static void RunCreateQuery(string query, bool isDatabase)
		{
			try
			{
				string conString;
				if (isDatabase)
					conString = String.Format("host = {0}; port = {1}; username = {2}; password = {3};", Connection.Host, Connection.Port,
						Connection.Decrypt(Connection.Username), Connection.Decrypt(Connection.Password));
				else
					conString = Connection.GenerateString();

				using (var con = new MySqlConnection(conString))
				{
					con.Open();
					using (var cmd = new MySqlCommand(query, con))
					{
						cmd.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return;
			}
		}

		private static void CreateAdminTable()
		{
			var query = "CREATE TABLE IF NOT EXISTS `admin`  (" +
			"`id` int NOT NULL AUTO_INCREMENT," +
			"`name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL," +
			"`surname` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL," +
			"`email` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL," +
			"`password` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL," +
			"`status` int NULL DEFAULT 1," +
			"PRIMARY KEY(`id`) USING BTREE" +
			") ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;";
			RunCreateQuery(query, false);
		}

		private static void CreateUsersTable()
		{
			var query = "CREATE TABLE IF NOT EXISTS `users`  (" +
			"`id` int NOT NULL AUTO_INCREMENT," +
			"`name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL," +
			"`surname` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL," +
			"`photo` mediumblob NULL," +
			"`description` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL," +
			"`post` int NULL DEFAULT NULL," +
			"PRIMARY KEY(`id`) USING BTREE" +
			") ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic; ";
			RunCreateQuery(query, false);
		}

		private static void CreateRoleTable()
		{
			var query = "CREATE TABLE IF NOT EXISTS `role`  (" +
			"`id` int NOT NULL AUTO_INCREMENT PRIMARY KEY," +
			"`name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL," +
			"`description` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL" +
			") ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic; ";
			RunCreateQuery(query, false);
		}

		private static void CreateUserLoginTable()
		{
			var query = "CREATE TABLE IF NOT EXISTS `user_login`  (" +
			"`id` int NOT NULL AUTO_INCREMENT," +
			"`username` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL," +
			"`email` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL," +
			"`password` varchar(300) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL," +
			"`status` int NULL DEFAULT 1," +
			"`role` int NULL DEFAULT NULL," +
			"`user` int NULL DEFAULT NULL," +
			"PRIMARY KEY(`id`) USING BTREE," +
			"INDEX `role`(`role`) USING BTREE," +
			" INDEX `user`(`user`) USING BTREE," +
			" CONSTRAINT `user_login_ibfk_1` FOREIGN KEY(`role`) REFERENCES `role` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT," +
			"CONSTRAINT `user_login_ibfk_2` FOREIGN KEY(`user`) REFERENCES `users` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT" +
			") ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic; ";
			RunCreateQuery(query, false);
		}

		private static void CreatePostTable()
		{
			var query = "CREATE TABLE IF NOT EXISTS `post`  (" +
			"`id` int NOT NULL AUTO_INCREMENT," +
			"`name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL," +
			"`topic` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL," +
			"`user` int NULL DEFAULT NULL," +
			"`post_date` datetime NULL DEFAULT NULL," +
			" PRIMARY KEY(`id`) USING BTREE," +
			" INDEX `user`(`user`) USING BTREE," +
			" CONSTRAINT `post_ibfk_1` FOREIGN KEY(`user`) REFERENCES `user_login` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT" +
			") ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic; ";
			RunCreateQuery(query, false);
		}

		private static void CreateCommentTable()
		{
			var query = "CREATE TABLE IF NOT EXISTS `comment`  (" +
			"`id` int NOT NULL AUTO_INCREMENT," +
			"`user` int NULL DEFAULT NULL," +
			"`post` int NULL DEFAULT NULL," +
			"`topic` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL," +
			"`post_date` datetime NULL DEFAULT NULL," +
			" PRIMARY KEY(`id`) USING BTREE," +
			" INDEX `post`(`post`) USING BTREE," +
			" INDEX `comment_ibfk_1`(`user`) USING BTREE," +
			" CONSTRAINT `comment_ibfk_1` FOREIGN KEY(`user`) REFERENCES `user_login` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT," +
			" CONSTRAINT `comment_ibfk_2` FOREIGN KEY(`post`) REFERENCES `post` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT" +
			") ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic; ";
			RunCreateQuery(query, false);
		}

		private static void CreateVoteTable()
		{
			var query = "CREATE TABLE IF NOT EXISTS `vote`  (" +
			"`id` int NOT NULL AUTO_INCREMENT," +
			"`user` int NULL DEFAULT NULL," +
			"`post` int NULL DEFAULT NULL," +
			"`vote` int NULL DEFAULT NULL," +
			" PRIMARY KEY(`id`) USING BTREE," +
			" INDEX `user`(`user`) USING BTREE," +
			" INDEX `post`(`post`) USING BTREE," +
			" CONSTRAINT `vote_ibfk_1` FOREIGN KEY(`user`) REFERENCES `user_login` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT," +
			" CONSTRAINT `vote_ibfk_2` FOREIGN KEY(`post`) REFERENCES `post` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT" +
			") ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic; ";
			RunCreateQuery(query, false);
		}
	}
}
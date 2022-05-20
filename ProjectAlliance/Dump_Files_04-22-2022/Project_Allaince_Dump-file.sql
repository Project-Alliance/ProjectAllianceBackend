-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: projetalliance
-- ------------------------------------------------------
-- Server version	8.0.27

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20220412104419_initial','3.1.22');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `company`
--

DROP TABLE IF EXISTS `company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `company` (
  `id` int NOT NULL AUTO_INCREMENT,
  `companyName` varchar(30) DEFAULT NULL,
  `createdBy` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `company`
--

LOCK TABLES `company` WRITE;
/*!40000 ALTER TABLE `company` DISABLE KEYS */;
INSERT INTO `company` VALUES (1,'codistan','rehan5@codistan.pa.com');
/*!40000 ALTER TABLE `company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `documentsection`
--

DROP TABLE IF EXISTS `documentsection`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `documentsection` (
  `sectionId` int NOT NULL AUTO_INCREMENT,
  `sectionName` varchar(30) DEFAULT NULL,
  `sectionDescription` text,
  `projectId` int NOT NULL,
  PRIMARY KEY (`sectionId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `documentsection`
--

LOCK TABLES `documentsection` WRITE;
/*!40000 ALTER TABLE `documentsection` DISABLE KEYS */;
INSERT INTO `documentsection` VALUES (1,'FYP New sectioon','new goals',1);
/*!40000 ALTER TABLE `documentsection` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `files`
--

DROP TABLE IF EXISTS `files`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `files` (
  `DocumentId` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `FileType` varchar(100) DEFAULT NULL,
  `DataFiles` varbinary(4000) DEFAULT NULL,
  `CreatedOn` datetime DEFAULT NULL,
  PRIMARY KEY (`DocumentId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `files`
--

LOCK TABLES `files` WRITE;
/*!40000 ALTER TABLE `files` DISABLE KEYS */;
/*!40000 ALTER TABLE `files` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `goals`
--

DROP TABLE IF EXISTS `goals`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `goals` (
  `id` int NOT NULL AUTO_INCREMENT,
  `goalName` varchar(30) DEFAULT NULL,
  `goalDescription` text,
  `startDate` date NOT NULL,
  `endDate` date NOT NULL,
  `companyId` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `goals`
--

LOCK TABLES `goals` WRITE;
/*!40000 ALTER TABLE `goals` DISABLE KEYS */;
INSERT INTO `goals` VALUES (2,'rehan\'s goal','new goal in the company','2022-04-17','2022-04-30',1),(6,'Project Allaince Goal','Here is the list of all goals','2022-04-04','2022-04-30',1),(7,'Mid term Goals','70% code will be complete ','2022-04-04','2022-04-30',1);
/*!40000 ALTER TABLE `goals` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `projectdocument`
--

DROP TABLE IF EXISTS `projectdocument`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `projectdocument` (
  `documentId` int NOT NULL AUTO_INCREMENT,
  `documentName` varchar(30) DEFAULT NULL,
  `documentDescription` text,
  `documentStatus` text,
  `uploadBy` text,
  `documentVersion` text,
  `filePath` text,
  `sectionId` int NOT NULL,
  `projectId` int NOT NULL,
  `documentFileExtension` text,
  PRIMARY KEY (`documentId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `projectdocument`
--

LOCK TABLES `projectdocument` WRITE;
/*!40000 ALTER TABLE `projectdocument` DISABLE KEYS */;
INSERT INTO `projectdocument` VALUES (1,'Rehn\'s doc','New one','Approved','1','16.2.1','7446b84e-d33d-4a14-9c3f-0c98e69a8f1fFiles.pdf',1,1,'.pdf');
/*!40000 ALTER TABLE `projectdocument` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `projects`
--

DROP TABLE IF EXISTS `projects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `projects` (
  `pid` int NOT NULL AUTO_INCREMENT,
  `ProjectTitle` text,
  `projectDescription` text,
  `status` text,
  `progress` text,
  `CreateAt` date NOT NULL,
  `companyProject` text,
  `startDate` date NOT NULL,
  `endDate` date NOT NULL,
  PRIMARY KEY (`pid`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `projects`
--

LOCK TABLES `projects` WRITE;
/*!40000 ALTER TABLE `projects` DISABLE KEYS */;
INSERT INTO `projects` VALUES (1,'rehan goris','jsdfjlsdf','On Track','0','2022-04-12','1','2022-04-12','2022-04-30');
/*!40000 ALTER TABLE `projects` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `projectteams`
--

DROP TABLE IF EXISTS `projectteams`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `projectteams` (
  `id` int NOT NULL AUTO_INCREMENT,
  `pid` int NOT NULL,
  `uid` int NOT NULL,
  `role` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `projectteams`
--

LOCK TABLES `projectteams` WRITE;
/*!40000 ALTER TABLE `projectteams` DISABLE KEYS */;
INSERT INTO `projectteams` VALUES (1,1,1,'Developer');
/*!40000 ALTER TABLE `projectteams` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `schedule`
--

DROP TABLE IF EXISTS `schedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `schedule` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(30) NOT NULL,
  `start` datetime NOT NULL,
  `end` datetime NOT NULL,
  `dependancies` text,
  `AssignTo` int NOT NULL,
  `progress` int NOT NULL,
  `ProjectId` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_Schedule_ProjectId` (`ProjectId`),
  CONSTRAINT `FK_Schedule_Projects_ProjectId` FOREIGN KEY (`ProjectId`) REFERENCES `projects` (`pid`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `schedule`
--

LOCK TABLES `schedule` WRITE;
/*!40000 ALTER TABLE `schedule` DISABLE KEYS */;
INSERT INTO `schedule` VALUES (11,'Requirement Elicitation','2022-04-15 00:00:00','2022-04-23 00:00:00','',1,90,1),(12,'Design','2022-04-21 00:00:00','2022-04-23 00:00:00','',1,30,1),(13,'Coding','2022-04-29 00:00:00','2022-05-02 00:00:00','12',1,50,1),(18,'testing','2022-04-22 00:00:00','2022-04-30 00:00:00','2',1,0,1),(19,'rehan work','2022-04-19 00:00:00','2022-04-29 00:00:00','',1,0,1),(20,'FYP Class','2022-04-18 00:00:00','2022-04-27 00:00:00','',1,0,1),(23,'New task','2022-04-10 00:00:00','2022-04-27 00:00:00','4',1,0,1),(25,'hkdsf','2022-04-12 00:00:00','2022-04-27 00:00:00','2',1,0,1),(26,'cgfhgfh','2022-04-10 00:00:00','2022-04-30 00:00:00','11',1,0,1),(27,'fdsfsd','2022-04-21 00:00:00','2022-04-26 00:00:00','43',1,0,1),(28,'cdcsdcc','2022-04-19 00:00:00','2022-04-28 00:00:00','13',1,0,1);
/*!40000 ALTER TABLE `schedule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subtasks`
--

DROP TABLE IF EXISTS `subtasks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subtasks` (
  `taskid` int NOT NULL AUTO_INCREMENT,
  `taskTitle` text,
  `startDate` date NOT NULL,
  `endDate` date NOT NULL,
  `description` text,
  `status` text,
  `progress` text,
  `CreateAt` date NOT NULL,
  PRIMARY KEY (`taskid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subtasks`
--

LOCK TABLES `subtasks` WRITE;
/*!40000 ALTER TABLE `subtasks` DISABLE KEYS */;
/*!40000 ALTER TABLE `subtasks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tasks`
--

DROP TABLE IF EXISTS `tasks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tasks` (
  `tid` int NOT NULL AUTO_INCREMENT,
  `TaskTitle` text,
  `ProjectId` int NOT NULL,
  `startDate` datetime NOT NULL,
  `endDate` date NOT NULL,
  `description` text,
  `status` text,
  `progress` text,
  `CreateAt` date NOT NULL,
  `TaskCost` text,
  PRIMARY KEY (`tid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tasks`
--

LOCK TABLES `tasks` WRITE;
/*!40000 ALTER TABLE `tasks` DISABLE KEYS */;
/*!40000 ALTER TABLE `tasks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(30) DEFAULT NULL,
  `password` text,
  `userName` text,
  `email` text,
  `profilePic` text,
  `phone` text,
  `Lastlogin` date NOT NULL,
  `role` text,
  `onlineStatus` text,
  `companyId` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'rehan','$2a$11$U33ByZOLTCdbWUBtKljxKO5TumMxtnRc7JidKwkZvGLAT2J2PyCdO','rehan5@codistan.pa.com','rehangoraya05@gmail.com',NULL,'19234893948','0001-01-01','admin',NULL,'1'),(2,'Rehan','$2a$11$Ft7CqksujIsSUf8q77FMJeQVQxq2kwfns9Gh5tUrCpBdWT.ob.Nqu','Rehan05@codistan.pa.com','rehangorayaya05@gmail.com',NULL,'923167722773','0001-01-01','Moderator',NULL,'1'),(3,'Azeem','$2a$11$MUDtD5GOjqb83jj0gAW/tudWBQu9kQzAqje9oi.1MTd78E3IY168i','Azeem05@codistan.pa.com','az1265513@gmail.com',NULL,'924384783483','0001-01-01','Moderator',NULL,'1');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-04-22 19:37:46

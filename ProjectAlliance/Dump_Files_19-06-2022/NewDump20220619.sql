-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: projectalliance
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
INSERT INTO `__efmigrationshistory` VALUES ('20220614182048_initial','3.1.22');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `boardcard`
--

DROP TABLE IF EXISTS `boardcard`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `boardcard` (
  `cid` int NOT NULL AUTO_INCREMENT,
  `lid` text,
  `title` text,
  `label` text,
  `description` text,
  `id` text,
  PRIMARY KEY (`cid`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `boardcard`
--

LOCK TABLES `boardcard` WRITE;
/*!40000 ALTER TABLE `boardcard` DISABLE KEYS */;
INSERT INTO `boardcard` VALUES (2,'44d099c2-56aa-490d-ad5c-aea5c95e330f','askdljaasd','aslkdj','alksjd','5563ce88-3830-4723-ab38-b79eda1bd8e2'),(3,'44d099c2-56aa-490d-ad5c-aea5c95e330f','Grant Permissions to Add','asdas','GRANT ALL PRIVILEGES ON *.* TO \'root\'@\'%\' IDENTIFIED BY \'root_password\';','72c70d5a-5e76-455a-853a-63f3b150abe1'),(6,'75e47006-a36f-4161-9486-7ac2230b5da6','OK','sakj','askljd','26749e7c-efd2-4ef6-8db9-f01bde446814'),(7,'75e47006-a36f-4161-9486-7ac2230b5da6','askljdkla','askdjakls','askjdkas','e23bb1ad-38e3-4049-ba5f-7ef3d0298dde'),(8,'75e47006-a36f-4161-9486-7ac2230b5da6','alsk;','lsajdkl','laskda','0d30303c-d628-4837-a102-f412604d6612'),(9,'75e47006-a36f-4161-9486-7ac2230b5da6','aksljdklas','kasljdkla','klasjdkals','b7ef9874-8f6c-475d-8208-78a24d9ed5f1'),(10,'75e47006-a36f-4161-9486-7ac2230b5da6','klasjdkla','ksldajaskl','skladjakls','9f1cc8a0-a18b-4dc6-899a-7e283399897f'),(13,'80adf589-5c29-4225-b2a8-a41c43834419','Grant Permissions to Add','Permission','GRANT ALL PRIVILEGES ON *.* TO \'root\'@\'%\' IDENTIFIED BY \'root_password\';','a8a0994f-03ea-4518-a5de-fd4980d20263');
/*!40000 ALTER TABLE `boardcard` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `boardlane`
--

DROP TABLE IF EXISTS `boardlane`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `boardlane` (
  `lid` int NOT NULL AUTO_INCREMENT,
  `projectId` int NOT NULL,
  `title` text,
  `label` text,
  `id` text,
  PRIMARY KEY (`lid`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `boardlane`
--

LOCK TABLES `boardlane` WRITE;
/*!40000 ALTER TABLE `boardlane` DISABLE KEYS */;
INSERT INTO `boardlane` VALUES (1,1,'Upcomming',NULL,'44d099c2-56aa-490d-ad5c-aea5c95e330f'),(2,1,'Due',NULL,'80adf589-5c29-4225-b2a8-a41c43834419'),(3,1,'Completed','','75e47006-a36f-4161-9486-7ac2230b5da6');
/*!40000 ALTER TABLE `boardlane` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `comments`
--

DROP TABLE IF EXISTS `comments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `comments` (
  `id` int NOT NULL AUTO_INCREMENT,
  `comId` text,
  `userId` int NOT NULL,
  `reqId` int NOT NULL,
  `text` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comments`
--

LOCK TABLES `comments` WRITE;
/*!40000 ALTER TABLE `comments` DISABLE KEYS */;
INSERT INTO `comments` VALUES (1,'e792e71d-a4a1-4d53-b4d6-c229188d3524',2,1,'Hi');
/*!40000 ALTER TABLE `comments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `commentsreplies`
--

DROP TABLE IF EXISTS `commentsreplies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `commentsreplies` (
  `id` int NOT NULL AUTO_INCREMENT,
  `userId` int NOT NULL,
  `comId` text,
  `text` text,
  `parentCommentId` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `commentsreplies`
--

LOCK TABLES `commentsreplies` WRITE;
/*!40000 ALTER TABLE `commentsreplies` DISABLE KEYS */;
/*!40000 ALTER TABLE `commentsreplies` ENABLE KEYS */;
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
INSERT INTO `company` VALUES (1,'uiit','as1265513@uiit.pa.com');
/*!40000 ALTER TABLE `company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `designattachments`
--

DROP TABLE IF EXISTS `designattachments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `designattachments` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` text,
  `designId` int NOT NULL,
  `AttachmentPath` text,
  `AttachmentExtension` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `designattachments`
--

LOCK TABLES `designattachments` WRITE;
/*!40000 ALTER TABLE `designattachments` DISABLE KEYS */;
/*!40000 ALTER TABLE `designattachments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `designs`
--

DROP TABLE IF EXISTS `designs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `designs` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Name` text,
  `Description` text,
  `url` text,
  `folderId` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `designs`
--

LOCK TABLES `designs` WRITE;
/*!40000 ALTER TABLE `designs` DISABLE KEYS */;
/*!40000 ALTER TABLE `designs` ENABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `documentsection`
--

LOCK TABLES `documentsection` WRITE;
/*!40000 ALTER TABLE `documentsection` DISABLE KEYS */;
/*!40000 ALTER TABLE `documentsection` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enviornment`
--

DROP TABLE IF EXISTS `enviornment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `enviornment` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Name` text,
  `Description` text,
  `summary` text,
  `projectId` int NOT NULL,
  `TestType` text,
  `RequirementId` int NOT NULL,
  `isRequirementBased` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enviornment`
--

LOCK TABLES `enviornment` WRITE;
/*!40000 ALTER TABLE `enviornment` DISABLE KEYS */;
INSERT INTO `enviornment` VALUES (1,'android','Android Testin','test on android ',1,'physical',0,0);
/*!40000 ALTER TABLE `enviornment` ENABLE KEYS */;
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
-- Table structure for table `folders`
--

DROP TABLE IF EXISTS `folders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `folders` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` text,
  `projectId` int NOT NULL,
  `modifiedBy` int NOT NULL,
  `folderType` text,
  `modifeidOn` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `folders`
--

LOCK TABLES `folders` WRITE;
/*!40000 ALTER TABLE `folders` DISABLE KEYS */;
/*!40000 ALTER TABLE `folders` ENABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `goals`
--

LOCK TABLES `goals` WRITE;
/*!40000 ALTER TABLE `goals` DISABLE KEYS */;
/*!40000 ALTER TABLE `goals` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `labresource`
--

DROP TABLE IF EXISTS `labresource`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `labresource` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Name` text,
  `value` text,
  `EnvId` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `labresource`
--

LOCK TABLES `labresource` WRITE;
/*!40000 ALTER TABLE `labresource` DISABLE KEYS */;
INSERT INTO `labresource` VALUES (1,'Camera','Physicla',1);
/*!40000 ALTER TABLE `labresource` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mail`
--

DROP TABLE IF EXISTS `mail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mail` (
  `id` int NOT NULL AUTO_INCREMENT,
  `subject` text,
  `title` text,
  `description` text,
  `time` datetime NOT NULL,
  `to` text,
  `from` text,
  `isRead` tinyint(1) NOT NULL,
  `isStared` tinyint(1) NOT NULL,
  `company` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mail`
--

LOCK TABLES `mail` WRITE;
/*!40000 ALTER TABLE `mail` DISABLE KEYS */;
INSERT INTO `mail` VALUES (1,'rhena','rehan','Sending  mail to. modarator','2022-06-16 12:39:10','rehan@uiit.pa.com','rehan@uiit.pa.com',1,1,'uiit'),(2,'rhena','rehan','Sending  mail to. modarator','2022-06-16 12:39:10','irtza@uiit.pa.com','rehan@uiit.pa.com',1,0,'uiit'),(3,'as','asd','asd','2022-06-16 12:42:01','as1265513@uiit.pa.com','rehan@uiit.pa.com',0,0,'uiit'),(4,'as','asd','asd','2022-06-16 12:42:01','rehan@uiit.pa.com','rehan@uiit.pa.com',1,1,'uiit'),(5,'as','asd','asd','2022-06-16 12:42:01','irtza@uiit.pa.com','rehan@uiit.pa.com',0,0,'uiit'),(6,'as','asd','asd','2022-06-16 12:42:01','hassn@uiit.pa.com','rehan@uiit.pa.com',0,0,'uiit'),(7,'as','asd','asd','2022-06-16 12:42:01','Nadeem@uiit.pa.com','rehan@uiit.pa.com',0,0,'uiit'),(8,'as','asd','asd','2022-06-16 12:42:01','umar@uiit.pa.com','rehan@uiit.pa.com',0,0,'uiit'),(9,'as','asd','asd','2022-06-16 12:42:01','john@uiit.pa.com','rehan@uiit.pa.com',0,0,'uiit'),(10,'as','asd','asd','2022-06-16 12:42:01','motu@uiit.pa.com','rehan@uiit.pa.com',0,0,'uiit'),(11,'as','asd','asd','2022-06-16 12:42:01','inspector@uiit.pa.com','rehan@uiit.pa.com',0,0,'uiit'),(12,'as','asd','asd','2022-06-16 12:42:01','bajwa@uiit.pa.com','rehan@uiit.pa.com',0,0,'uiit'),(13,'Test Mail','Pakistan','This is test mail.','2022-06-18 13:12:15','as1265513@gmail.com','rehan@uiit.pa.com',0,0,'uiit'),(14,'Test Mail','Pakistan','This is test mail.','2022-06-18 13:12:16','rehangoraya05@gmail.com','rehan@uiit.pa.com',0,0,'uiit'),(15,'Test Mail','Pakistan','This is test mail.','2022-06-18 13:12:16','irtza11@gmail.com','rehan@uiit.pa.com',0,0,'uiit'),(16,'Test Mail','Pakistan','This is test mail.','2022-06-18 13:12:16','hassan@gmail.com','rehan@uiit.pa.com',0,0,'uiit'),(17,'Test Mail','Pakistan','This is test mail.','2022-06-18 13:12:16','Nadeem@gmail.com','rehan@uiit.pa.com',0,0,'uiit'),(18,'Test Mail','Pakistan','This is test mail.','2022-06-18 13:12:16','umar@gmail.com','rehan@uiit.pa.com',0,0,'uiit'),(19,'Test Mail','Pakistan','This is test mail.','2022-06-18 13:12:16','john@gmail.com','rehan@uiit.pa.com',0,0,'uiit'),(20,'Test Mail','Pakistan','This is test mail.','2022-06-18 13:12:16','motu@gmail.com','rehan@uiit.pa.com',0,0,'uiit'),(21,'Test Mail','Pakistan','This is test mail.','2022-06-18 13:12:16','inspector@gmail.com','rehan@uiit.pa.com',0,0,'uiit'),(22,'Test Mail','Pakistan','This is test mail.','2022-06-18 13:12:16','bajwa@gmail.com','rehan@uiit.pa.com',0,0,'uiit'),(23,'Test Mail','Pakistan','This is test mail.','2022-06-18 13:12:16','khan@gmail.com','rehan@uiit.pa.com',0,0,'uiit'),(24,'Ok ','asdasd','sad','2022-06-18 13:13:06','as1265513@gmail.com','rehan@uiit.pa.com',0,0,'uiit'),(25,'sadsa','asdas','sada','2022-06-18 13:16:13','as1265513@uiit.pa.com','rehan@uiit.pa.com',0,0,'uiit'),(26,'sadsa','asdas','sada','2022-06-18 13:16:13','rehan@uiit.pa.com','rehan@uiit.pa.com',0,0,'uiit'),(27,'Dail TAsk Alert','YOu have some task pending ','Pleased complete YOur task and submit to your team leads.','2022-06-18 13:17:33','rehan@uiit.pa.com','rehan@uiit.pa.com',0,0,'uiit'),(28,'Figma File','File Have sent to you','Please check Figma file And create design according to Ui.','2022-06-18 13:19:02','rehan@uiit.pa.com','rehan@uiit.pa.com',0,0,'uiit'),(29,'Meeting Call ','Meeting','Meeting Will held on Zoom TO disscuss Project.','2022-06-18 13:20:07','rehan@uiit.pa.com','rehan@uiit.pa.com',0,0,'uiit'),(30,'Meeting Call ','Meeting','Meeting Will held on Zoom TO disscuss Project.','2022-06-18 13:20:07','as1265513@uiit.pa.com','rehan@uiit.pa.com',0,0,'uiit'),(31,'Meeting Call ','Meeting','Meeting Will held on Zoom TO disscuss Project.','2022-06-18 13:20:07','irtza@uiit.pa.com','rehan@uiit.pa.com',0,0,'uiit'),(32,'Meeting Call','Meeting Call ','Hy pleas join Meetin Usiing Below link','2022-06-18 13:21:07','rehan@uiit.pa.com','rehan@uiit.pa.com',0,0,'uiit'),(33,'Meeting Call','Meeting Call ','Hy pleas join Meetin Usiing Below link','2022-06-18 13:21:07','irtza@uiit.pa.com','rehan@uiit.pa.com',0,0,'uiit'),(34,'Meetin','Meeting Reply','Okas','2022-06-18 13:44:22','rehan@uiit.pa.com','as1265513@uiit.pa.com',1,1,'uiit');
/*!40000 ALTER TABLE `mail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mailattachments`
--

DROP TABLE IF EXISTS `mailattachments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mailattachments` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` text,
  `emailId` int NOT NULL,
  `path` text,
  `ext` text,
  `fakeName` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mailattachments`
--

LOCK TABLES `mailattachments` WRITE;
/*!40000 ALTER TABLE `mailattachments` DISABLE KEYS */;
INSERT INTO `mailattachments` VALUES (1,'240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',1,'http://192.168.43.107:5005/api/Document/FileAPI/a73e4185-8730-4616-88e6-e5320df4d235Files.docx','a73e4185-8730-4616-88e6-e5320df4d235Files.docx',NULL),(2,'240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',2,'http://192.168.43.107:5005/api/Document/FileAPI/6cbb9fd9-bea2-4c78-96a5-254fceb0abe9Files.docx','6cbb9fd9-bea2-4c78-96a5-254fceb0abe9Files.docx',NULL),(3,'240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',13,'http://192.168.43.107:5005/api/Document/FileAPI/4ea5e25f-1586-4863-9470-fe8015d5340cFiles.docx','4ea5e25f-1586-4863-9470-fe8015d5340cFiles.docx',NULL),(4,'arch-diagram_nodejs-app.4c8966fcddcba4e101b955905cf88d99d4c9dcd5.png',13,'http://192.168.43.107:5005/api/Document/FileAPI/596939ee-1c41-4a9c-91fb-03fb4802139bFiles.png','596939ee-1c41-4a9c-91fb-03fb4802139bFiles.png',NULL),(5,'Arqum Resume— 18 March, 20.40.06.sketch',13,'http://192.168.43.107:5005/api/Document/FileAPI/88765e4d-5f0d-4b15-aba0-2008a5a3f387Files.sketch','88765e4d-5f0d-4b15-aba0-2008a5a3f387Files.sketch',NULL),(6,'Arqum Resume— 18 March, 20.40.06.sketch',14,'http://192.168.43.107:5005/api/Document/FileAPI/c484d3ab-3fc2-44e8-8c51-fec2c86c7b9eFiles.sketch','c484d3ab-3fc2-44e8-8c51-fec2c86c7b9eFiles.sketch',NULL),(7,'arch-diagram_nodejs-app.4c8966fcddcba4e101b955905cf88d99d4c9dcd5.png',14,'http://192.168.43.107:5005/api/Document/FileAPI/82cca2ec-a326-44d7-8705-8d1c9c12dac1Files.png','82cca2ec-a326-44d7-8705-8d1c9c12dac1Files.png',NULL),(8,'240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',14,'http://192.168.43.107:5005/api/Document/FileAPI/1065c54d-56f5-478f-b6d2-7f99c6b4ba84Files.docx','1065c54d-56f5-478f-b6d2-7f99c6b4ba84Files.docx',NULL),(9,'Arqum Resume— 18 March, 20.40.06.sketch',15,'http://192.168.43.107:5005/api/Document/FileAPI/472893e1-ac2b-42c5-b74c-c844b6da1d56Files.sketch','472893e1-ac2b-42c5-b74c-c844b6da1d56Files.sketch',NULL),(10,'arch-diagram_nodejs-app.4c8966fcddcba4e101b955905cf88d99d4c9dcd5.png',15,'http://192.168.43.107:5005/api/Document/FileAPI/11bc05eb-0d68-426c-84d2-12a20734c19cFiles.png','11bc05eb-0d68-426c-84d2-12a20734c19cFiles.png',NULL),(11,'240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',15,'http://192.168.43.107:5005/api/Document/FileAPI/a80d34e6-3ea3-4708-a41b-6d15ddbf5c85Files.docx','a80d34e6-3ea3-4708-a41b-6d15ddbf5c85Files.docx',NULL),(12,'Arqum Resume— 18 March, 20.40.06.sketch',16,'http://192.168.43.107:5005/api/Document/FileAPI/d28628e4-85f6-45e0-ac6d-f43b81cb497eFiles.sketch','d28628e4-85f6-45e0-ac6d-f43b81cb497eFiles.sketch',NULL),(13,'arch-diagram_nodejs-app.4c8966fcddcba4e101b955905cf88d99d4c9dcd5.png',16,'http://192.168.43.107:5005/api/Document/FileAPI/e059c17a-10e5-4955-bffd-8ea3165d06f3Files.png','e059c17a-10e5-4955-bffd-8ea3165d06f3Files.png',NULL),(14,'240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',16,'http://192.168.43.107:5005/api/Document/FileAPI/5cded5be-de07-499a-b299-43b5b95f2b95Files.docx','5cded5be-de07-499a-b299-43b5b95f2b95Files.docx',NULL),(15,'Arqum Resume— 18 March, 20.40.06.sketch',17,'http://192.168.43.107:5005/api/Document/FileAPI/f6a5fc91-27e8-4f70-bd67-445331c97194Files.sketch','f6a5fc91-27e8-4f70-bd67-445331c97194Files.sketch',NULL),(16,'arch-diagram_nodejs-app.4c8966fcddcba4e101b955905cf88d99d4c9dcd5.png',17,'http://192.168.43.107:5005/api/Document/FileAPI/0ccedeea-5095-4d04-8464-dca25650df74Files.png','0ccedeea-5095-4d04-8464-dca25650df74Files.png',NULL),(17,'240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',17,'http://192.168.43.107:5005/api/Document/FileAPI/1f4ca7ae-a660-4d1c-af89-3e5a1d7d5048Files.docx','1f4ca7ae-a660-4d1c-af89-3e5a1d7d5048Files.docx',NULL),(18,'Arqum Resume— 18 March, 20.40.06.sketch',18,'http://192.168.43.107:5005/api/Document/FileAPI/2cdf3281-b279-4269-8ae2-59635ac578afFiles.sketch','2cdf3281-b279-4269-8ae2-59635ac578afFiles.sketch',NULL),(19,'arch-diagram_nodejs-app.4c8966fcddcba4e101b955905cf88d99d4c9dcd5.png',18,'http://192.168.43.107:5005/api/Document/FileAPI/1c6019b7-9261-4851-b44a-0680faf07cbeFiles.png','1c6019b7-9261-4851-b44a-0680faf07cbeFiles.png',NULL),(20,'240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',18,'http://192.168.43.107:5005/api/Document/FileAPI/c83f466d-2f02-4c40-8a3a-c62d8af7cb75Files.docx','c83f466d-2f02-4c40-8a3a-c62d8af7cb75Files.docx',NULL),(21,'Arqum Resume— 18 March, 20.40.06.sketch',19,'http://192.168.43.107:5005/api/Document/FileAPI/4fc8a417-49ea-4afc-b1db-2144ecf2b269Files.sketch','4fc8a417-49ea-4afc-b1db-2144ecf2b269Files.sketch',NULL),(22,'arch-diagram_nodejs-app.4c8966fcddcba4e101b955905cf88d99d4c9dcd5.png',19,'http://192.168.43.107:5005/api/Document/FileAPI/e32bab28-63be-446d-9e78-2e4f9eaee2b3Files.png','e32bab28-63be-446d-9e78-2e4f9eaee2b3Files.png',NULL),(23,'240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',19,'http://192.168.43.107:5005/api/Document/FileAPI/2cd5bb61-3e49-4af7-bd08-b2b03980d1c6Files.docx','2cd5bb61-3e49-4af7-bd08-b2b03980d1c6Files.docx',NULL),(24,'Arqum Resume— 18 March, 20.40.06.sketch',20,'http://192.168.43.107:5005/api/Document/FileAPI/7ca09455-8510-44c8-93ec-eb82ab67bebbFiles.sketch','7ca09455-8510-44c8-93ec-eb82ab67bebbFiles.sketch',NULL),(25,'arch-diagram_nodejs-app.4c8966fcddcba4e101b955905cf88d99d4c9dcd5.png',20,'http://192.168.43.107:5005/api/Document/FileAPI/aeed614f-9640-4c3d-b13c-666e8b013b1aFiles.png','aeed614f-9640-4c3d-b13c-666e8b013b1aFiles.png',NULL),(26,'240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',20,'http://192.168.43.107:5005/api/Document/FileAPI/77094ee4-2fa0-46ce-93f9-c04200c17a18Files.docx','77094ee4-2fa0-46ce-93f9-c04200c17a18Files.docx',NULL),(27,'Arqum Resume— 18 March, 20.40.06.sketch',21,'http://192.168.43.107:5005/api/Document/FileAPI/0bb00526-21f2-437e-92f7-165940d5f811Files.sketch','0bb00526-21f2-437e-92f7-165940d5f811Files.sketch',NULL),(28,'arch-diagram_nodejs-app.4c8966fcddcba4e101b955905cf88d99d4c9dcd5.png',21,'http://192.168.43.107:5005/api/Document/FileAPI/f1fdd165-9dbb-4f81-85ab-9e43c95383feFiles.png','f1fdd165-9dbb-4f81-85ab-9e43c95383feFiles.png',NULL),(29,'240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',21,'http://192.168.43.107:5005/api/Document/FileAPI/5faa11d0-22cb-4e9e-9b54-b934df735dc6Files.docx','5faa11d0-22cb-4e9e-9b54-b934df735dc6Files.docx',NULL),(30,'Arqum Resume— 18 March, 20.40.06.sketch',22,'http://192.168.43.107:5005/api/Document/FileAPI/4d7f7a14-068a-44af-aaf1-e09f2a2ca163Files.sketch','4d7f7a14-068a-44af-aaf1-e09f2a2ca163Files.sketch',NULL),(31,'arch-diagram_nodejs-app.4c8966fcddcba4e101b955905cf88d99d4c9dcd5.png',22,'http://192.168.43.107:5005/api/Document/FileAPI/660eb809-ed3d-460b-a61c-24839fb38ceeFiles.png','660eb809-ed3d-460b-a61c-24839fb38ceeFiles.png',NULL),(32,'240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',22,'http://192.168.43.107:5005/api/Document/FileAPI/2482c2e0-a1a2-4c8c-a12e-81437549a67dFiles.docx','2482c2e0-a1a2-4c8c-a12e-81437549a67dFiles.docx',NULL),(33,'Arqum Resume— 18 March, 20.40.06.sketch',23,'http://192.168.43.107:5005/api/Document/FileAPI/f8076b9b-2a49-4c94-a3e0-0a651eeb4d4dFiles.sketch','f8076b9b-2a49-4c94-a3e0-0a651eeb4d4dFiles.sketch',NULL),(34,'arch-diagram_nodejs-app.4c8966fcddcba4e101b955905cf88d99d4c9dcd5.png',23,'http://192.168.43.107:5005/api/Document/FileAPI/0da22858-935d-403c-9c0e-ac9cff1250b5Files.png','0da22858-935d-403c-9c0e-ac9cff1250b5Files.png',NULL),(35,'240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',23,'http://192.168.43.107:5005/api/Document/FileAPI/cc6ca056-23e0-40f1-b1a5-ced70a247daaFiles.docx','cc6ca056-23e0-40f1-b1a5-ced70a247daaFiles.docx',NULL),(36,'240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',24,'http://192.168.43.107:5005/api/Document/FileAPI/b447ebf8-c4e9-486e-ac36-e74bfc67b924Files.docx','b447ebf8-c4e9-486e-ac36-e74bfc67b924Files.docx',NULL),(37,'240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',27,'http://192.168.43.107:5005/api/Document/FileAPI/00a6633e-b5f0-4e62-b9bc-213c2d42802fFiles.docx','00a6633e-b5f0-4e62-b9bc-213c2d42802fFiles.docx',NULL),(38,'Arqum Resume— 18 March, 20.40.06.sketch',28,'http://192.168.43.107:5005/api/Document/FileAPI/1092439a-9978-4df1-9e49-3d7df2ffb803Files.sketch','1092439a-9978-4df1-9e49-3d7df2ffb803Files.sketch',NULL),(39,'arch-diagram_nodejs-app.4c8966fcddcba4e101b955905cf88d99d4c9dcd5.png',29,'http://192.168.43.107:5005/api/Document/FileAPI/5df9dcd5-c882-442c-babe-b79fa276af61Files.png','5df9dcd5-c882-442c-babe-b79fa276af61Files.png',NULL),(40,'arch-diagram_nodejs-app.4c8966fcddcba4e101b955905cf88d99d4c9dcd5.png',30,'http://192.168.43.107:5005/api/Document/FileAPI/228b08ba-3af1-43b4-a45d-54164dcfd25fFiles.png','228b08ba-3af1-43b4-a45d-54164dcfd25fFiles.png',NULL),(41,'arch-diagram_nodejs-app.4c8966fcddcba4e101b955905cf88d99d4c9dcd5.png',31,'http://192.168.43.107:5005/api/Document/FileAPI/62a36759-b1ad-491d-80a8-c08a2aa18097Files.png','62a36759-b1ad-491d-80a8-c08a2aa18097Files.png',NULL);
/*!40000 ALTER TABLE `mailattachments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `permisions`
--

DROP TABLE IF EXISTS `permisions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `permisions` (
  `permisionId` int NOT NULL AUTO_INCREMENT,
  `permisionTitle` text,
  `create` tinyint(1) NOT NULL,
  `update` tinyint(1) NOT NULL,
  `Delete` tinyint(1) NOT NULL,
  `read` tinyint(1) NOT NULL,
  `userId` int NOT NULL,
  PRIMARY KEY (`permisionId`)
) ENGINE=InnoDB AUTO_INCREMENT=132 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permisions`
--

LOCK TABLES `permisions` WRITE;
/*!40000 ALTER TABLE `permisions` DISABLE KEYS */;
INSERT INTO `permisions` VALUES (1,'superUser',1,1,1,1,1),(2,'manageMember',1,1,0,1,2),(3,'manageProjects',1,1,0,1,2),(4,'manageTasks',1,1,0,1,2),(5,'goalsManagement',1,1,0,1,2),(6,'managePermisions',1,1,0,1,2),(7,'manageRoles',1,1,0,1,2),(8,'manageUsers',1,1,0,1,2),(9,'manageReports',1,1,0,1,2),(10,'manageSettings',1,1,0,1,2),(11,'manageNotifications',1,1,0,1,2),(12,'manageCalendar',1,1,0,1,2),(13,'manageFiles',1,1,0,1,2),(14,'manageMessages',1,1,0,1,2),(15,'manageMember',1,1,0,1,3),(16,'manageProjects',1,1,0,1,3),(17,'manageTasks',1,1,0,1,3),(18,'goalsManagement',1,1,0,1,3),(19,'managePermisions',1,1,0,1,3),(20,'manageRoles',1,1,0,1,3),(21,'manageUsers',1,1,0,1,3),(22,'manageReports',1,1,0,1,3),(23,'manageSettings',1,1,0,1,3),(24,'manageNotifications',1,1,0,1,3),(25,'manageCalendar',1,1,0,1,3),(26,'manageFiles',1,1,0,1,3),(27,'manageMessages',1,1,0,1,3),(28,'manageMember',0,0,0,1,4),(29,'manageProjects',0,0,0,1,4),(30,'manageTasks',0,0,0,1,4),(31,'goalsManagement',0,0,0,1,4),(32,'managePermisions',0,0,0,1,4),(33,'manageRoles',0,0,0,1,4),(34,'manageUsers',0,0,0,1,4),(35,'manageReports',0,0,0,1,4),(36,'manageSettings',0,0,0,1,4),(37,'manageNotifications',0,0,0,1,4),(38,'manageCalendar',0,0,0,1,4),(39,'manageFiles',0,0,0,1,4),(40,'manageMessages',0,0,0,1,4),(41,'manageMember',0,0,0,1,5),(42,'manageProjects',0,0,0,1,5),(43,'manageTasks',0,0,0,1,5),(44,'goalsManagement',0,0,0,1,5),(45,'managePermisions',0,0,0,1,5),(46,'manageRoles',0,0,0,1,5),(47,'manageUsers',0,0,0,1,5),(48,'manageReports',0,0,0,1,5),(49,'manageSettings',0,0,0,1,5),(50,'manageNotifications',0,0,0,1,5),(51,'manageCalendar',0,0,0,1,5),(52,'manageFiles',0,0,0,1,5),(53,'manageMessages',0,0,0,1,5),(54,'manageMember',0,0,0,1,6),(55,'manageProjects',0,0,0,1,6),(56,'manageTasks',0,0,0,1,6),(57,'goalsManagement',0,0,0,1,6),(58,'managePermisions',0,0,0,1,6),(59,'manageRoles',0,0,0,1,6),(60,'manageUsers',0,0,0,1,6),(61,'manageReports',0,0,0,1,6),(62,'manageSettings',0,0,0,1,6),(63,'manageNotifications',0,0,0,1,6),(64,'manageCalendar',0,0,0,1,6),(65,'manageFiles',0,0,0,1,6),(66,'manageMessages',0,0,0,1,6),(67,'manageMember',0,0,0,1,7),(68,'manageProjects',0,0,0,1,7),(69,'manageTasks',0,0,0,1,7),(70,'goalsManagement',0,0,0,1,7),(71,'managePermisions',0,0,0,1,7),(72,'manageRoles',0,0,0,1,7),(73,'manageUsers',0,0,0,1,7),(74,'manageReports',0,0,0,1,7),(75,'manageSettings',0,0,0,1,7),(76,'manageNotifications',0,0,0,1,7),(77,'manageCalendar',0,0,0,1,7),(78,'manageFiles',0,0,0,1,7),(79,'manageMessages',0,0,0,1,7),(80,'manageMember',0,0,0,1,8),(81,'manageProjects',0,0,0,1,8),(82,'manageTasks',0,0,0,1,8),(83,'goalsManagement',0,0,0,1,8),(84,'managePermisions',0,0,0,1,8),(85,'manageRoles',0,0,0,1,8),(86,'manageUsers',0,0,0,1,8),(87,'manageReports',0,0,0,1,8),(88,'manageSettings',0,0,0,1,8),(89,'manageNotifications',0,0,0,1,8),(90,'manageCalendar',0,0,0,1,8),(91,'manageFiles',0,0,0,1,8),(92,'manageMessages',0,0,0,1,8),(93,'manageMember',0,0,0,1,9),(94,'manageProjects',0,0,0,1,9),(95,'manageTasks',0,0,0,1,9),(96,'goalsManagement',0,0,0,1,9),(97,'managePermisions',0,0,0,1,9),(98,'manageRoles',0,0,0,1,9),(99,'manageUsers',0,0,0,1,9),(100,'manageReports',0,0,0,1,9),(101,'manageSettings',0,0,0,1,9),(102,'manageNotifications',0,0,0,1,9),(103,'manageCalendar',0,0,0,1,9),(104,'manageFiles',0,0,0,1,9),(105,'manageMessages',0,0,0,1,9),(106,'manageMember',0,0,0,1,10),(107,'manageProjects',0,0,0,1,10),(108,'manageTasks',0,0,0,1,10),(109,'goalsManagement',0,0,0,1,10),(110,'managePermisions',0,0,0,1,10),(111,'manageRoles',0,0,0,1,10),(112,'manageUsers',0,0,0,1,10),(113,'manageReports',0,0,0,1,10),(114,'manageSettings',0,0,0,1,10),(115,'manageNotifications',0,0,0,1,10),(116,'manageCalendar',0,0,0,1,10),(117,'manageFiles',0,0,0,1,10),(118,'manageMessages',0,0,0,1,10),(119,'manageMember',0,0,0,1,11),(120,'manageProjects',0,0,0,1,11),(121,'manageTasks',0,0,0,1,11),(122,'goalsManagement',0,0,0,1,11),(123,'managePermisions',0,0,0,1,11),(124,'manageRoles',0,0,0,1,11),(125,'manageUsers',0,0,0,1,11),(126,'manageReports',0,0,0,1,11),(127,'manageSettings',0,0,0,1,11),(128,'manageNotifications',0,0,0,1,11),(129,'manageCalendar',0,0,0,1,11),(130,'manageFiles',0,0,0,1,11),(131,'manageMessages',0,0,0,1,11);
/*!40000 ALTER TABLE `permisions` ENABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `projectdocument`
--

LOCK TABLES `projectdocument` WRITE;
/*!40000 ALTER TABLE `projectdocument` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `projects`
--

LOCK TABLES `projects` WRITE;
/*!40000 ALTER TABLE `projects` DISABLE KEYS */;
INSERT INTO `projects` VALUES (1,'Pakistan12','asldk','On Track','0','2022-06-15','1','2022-06-15','2022-07-13'),(2,'Project Allaince','Here is our Project','On Track','0','2022-06-16','1','2022-06-13','2022-07-02'),(3,'Notification Test','Test','On Track','0','2022-06-18','1','2022-06-18','2022-07-09'),(4,'Noti','Notify','On Track','0','2022-06-18','1','2022-06-25','2022-07-02');
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
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `projectteams`
--

LOCK TABLES `projectteams` WRITE;
/*!40000 ALTER TABLE `projectteams` DISABLE KEYS */;
INSERT INTO `projectteams` VALUES (1,1,1,'Requirement Engineer'),(2,1,2,'Scrum Master'),(3,2,1,'Requirement Engineer'),(4,1,5,'Developer'),(5,1,7,'Designer'),(6,1,8,'Scrum Master'),(7,1,10,'Business Analyst'),(8,2,2,'Product Owner'),(9,2,3,'Developer'),(10,2,4,'Developer'),(11,2,6,'Tester'),(12,2,9,'Requirement Engineer'),(13,3,6,'Scrum Master'),(14,3,2,'Product Owner'),(15,3,1,'Developer'),(16,4,1,'Designer');
/*!40000 ALTER TABLE `projectteams` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `qualityschedule`
--

DROP TABLE IF EXISTS `qualityschedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `qualityschedule` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(30) NOT NULL,
  `start` datetime NOT NULL,
  `end` datetime NOT NULL,
  `dependancies` text,
  `AssignTo` int NOT NULL,
  `progress` int NOT NULL,
  `ProjectId` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_QualitySchedule_ProjectId` (`ProjectId`),
  CONSTRAINT `FK_QualitySchedule_Projects_ProjectId` FOREIGN KEY (`ProjectId`) REFERENCES `projects` (`pid`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `qualityschedule`
--

LOCK TABLES `qualityschedule` WRITE;
/*!40000 ALTER TABLE `qualityschedule` DISABLE KEYS */;
/*!40000 ALTER TABLE `qualityschedule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `requirementattachments`
--

DROP TABLE IF EXISTS `requirementattachments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `requirementattachments` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` text,
  `requirementId` int NOT NULL,
  `AttachmentPath` text,
  `AttachmentExtension` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `requirementattachments`
--

LOCK TABLES `requirementattachments` WRITE;
/*!40000 ALTER TABLE `requirementattachments` DISABLE KEYS */;
INSERT INTO `requirementattachments` VALUES (1,'Assignment-II (3415).pdf',1,'112fae9d-f251-431a-a361-c22fbe5469d9Files.pdf','.pdf'),(2,'240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',1,'83353d95-b18d-4091-ae43-87b536f14f89Files.docx','.docx'),(3,'240dcb86-0be6-4c4b-8ecd-88664755c2f6Files.docx',1,'e3323377-33ce-49d2-9b95-faeffa722043Files.docx','.docx'),(4,'images.jpeg',1,'b15ad792-dfb6-4fb2-9d69-55cf6e181c30Files.jpeg','.jpeg');
/*!40000 ALTER TABLE `requirementattachments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `requirements`
--

DROP TABLE IF EXISTS `requirements`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `requirements` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(30) NOT NULL,
  `status` text,
  `requirementDescription` text,
  `requirementType` text,
  `modifiedBy` text,
  `modifeidOn` date NOT NULL,
  `moduleId` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `requirements`
--

LOCK TABLES `requirements` WRITE;
/*!40000 ALTER TABLE `requirements` DISABLE KEYS */;
INSERT INTO `requirements` VALUES (1,'asd','asdas','asdas','asdas','1','2022-06-15',1);
/*!40000 ALTER TABLE `requirements` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `requirementsmodule`
--

DROP TABLE IF EXISTS `requirementsmodule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `requirementsmodule` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` text,
  `status` text,
  `modifiedBy` text,
  `modifeidOn` date NOT NULL,
  `projectId` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `requirementsmodule`
--

LOCK TABLES `requirementsmodule` WRITE;
/*!40000 ALTER TABLE `requirementsmodule` DISABLE KEYS */;
INSERT INTO `requirementsmodule` VALUES (1,'Aurh','Auth','1','2022-06-15',1);
/*!40000 ALTER TABLE `requirementsmodule` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `schedule`
--

LOCK TABLES `schedule` WRITE;
/*!40000 ALTER TABLE `schedule` DISABLE KEYS */;
INSERT INTO `schedule` VALUES (1,'REhan\'s task','2022-06-20 00:00:00','2022-06-23 00:00:00','0',1,100,1),(2,'New module','2022-06-22 23:00:00','2022-06-24 23:00:00','1',1,100,1),(3,'Change Module','2022-06-24 09:00:00','2022-06-25 04:00:00','2',1,100,1),(4,'Requirement module','2022-06-29 00:00:00','2022-07-09 00:00:00','1',1,100,1),(5,'Quality Module','2022-06-24 00:00:00','2022-08-07 00:00:00','1',1,100,1),(6,'Goals Module','2022-06-24 14:00:00','2022-06-28 09:00:00','2',1,100,1),(7,'Account module','2022-06-26 09:00:00','2022-06-26 23:00:00','2',1,100,1),(8,'Invite Team Mate','2022-06-25 00:00:00','2022-07-02 00:00:00','2',1,0,1),(9,'Settings Module','2022-06-24 00:00:00','2022-06-27 00:00:00','2',1,100,1),(10,'Help Module','2022-06-25 23:00:00','2022-06-28 08:00:00','2',1,42,1),(11,'New one\'s','2022-06-24 09:00:00','2022-06-27 13:00:00','3',1,75,1),(12,'Complete','2022-06-24 23:00:00','2022-06-30 13:00:00','2',1,100,1);
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
-- Table structure for table `testcaseattachment`
--

DROP TABLE IF EXISTS `testcaseattachment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `testcaseattachment` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` text,
  `testresultId` int NOT NULL,
  `AttachmentPath` text,
  `AttachmentExtension` text,
  `AtttachmentType` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `testcaseattachment`
--

LOCK TABLES `testcaseattachment` WRITE;
/*!40000 ALTER TABLE `testcaseattachment` DISABLE KEYS */;
INSERT INTO `testcaseattachment` VALUES (1,'9597f37a-59bc-4449-8b8b-d4797643f85fFiles.pdf',1,'f7b818d6-ef5b-45c1-bf32-17b8725e2ce2Files.pdf','.pdf','ExpectedOutcome'),(2,'flobroLOGO.png',1,'d2a3ce94-733d-4704-9d88-816a8c7fddbbFiles.png','.png','testOutCome');
/*!40000 ALTER TABLE `testcaseattachment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `testcases`
--

DROP TABLE IF EXISTS `testcases`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `testcases` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Name` text,
  `categoryName` text,
  `categoryType` text,
  `testType` text,
  `testPlanId` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `testcases`
--

LOCK TABLES `testcases` WRITE;
/*!40000 ALTER TABLE `testcases` DISABLE KEYS */;
INSERT INTO `testcases` VALUES (1,'asd','ads','asd','asdas',1),(2,'asd','sadd','adsd','asdasdas',1);
/*!40000 ALTER TABLE `testcases` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `testplan`
--

DROP TABLE IF EXISTS `testplan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `testplan` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Name` text,
  `Description` text,
  `EnvId` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `testplan`
--

LOCK TABLES `testplan` WRITE;
/*!40000 ALTER TABLE `testplan` DISABLE KEYS */;
INSERT INTO `testplan` VALUES (1,'Test phisical','sdkfljsd',1);
/*!40000 ALTER TABLE `testplan` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `testresult`
--

DROP TABLE IF EXISTS `testresult`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `testresult` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Description` text,
  `testId` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `testresult`
--

LOCK TABLES `testresult` WRITE;
/*!40000 ALTER TABLE `testresult` DISABLE KEYS */;
INSERT INTO `testresult` VALUES (1,'dssa',1);
/*!40000 ALTER TABLE `testresult` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Azeem','$2a$11$T0OgyRo9v/ngB3NKLWObYugzdWB4IL6jTU4u7Y0cscUgvqTZ/f8nK','as1265513@uiit.pa.com','as1265513@gmail.com','bb2070dd-8f72-403a-a31f-d944ae84a5e5Files.jpeg','+92346-0429461','0001-01-01','admin',NULL,'1'),(2,'Rehan ','$2a$11$nuyHL1TQXvoujuQ/IM.bO.Or6ipNhV9R7lI5gqE9zDjl34ymN1XAG','rehan@uiit.pa.com','rehangoraya05@gmail.com','05279ba2-015f-4fa4-ad4b-91c7edb26c1eFiles.jpeg','923460223789','0001-01-01','Moderator',NULL,'1'),(3,'irtza','$2a$11$BBbvnMESQeUy.bzzLwX9re5GMx0X3jdULPdlS7nOF2ifaWyGba6Se','irtza@uiit.pa.com','irtza11@gmail.com',NULL,'923394894790','0001-01-01','Moderator',NULL,'1'),(4,'hassan','$2a$11$.p10zeTELdirCEN47lSF6OI0.liE4a8WUXSZHwF.Wl2P1TkKbmpMS','hassn@uiit.pa.com','hassan@gmail.com',NULL,'12312312312','0001-01-01','Member',NULL,'1'),(5,'Nadeem','$2a$11$Bex13X8i2Z57TU8WG/v.gukBpgWE3GAtdLZnIpG.33jomUCKBxwdS','Nadeem@uiit.pa.com','Nadeem@gmail.com',NULL,'924783992832','0001-01-01','Member',NULL,'1'),(6,'umar','$2a$11$YUdE4JVOnMO7/EjGFhb1FONKQh77nfv35ixR63b3HOx2eXi12.lvC','umar@uiit.pa.com','umar@gmail.com',NULL,'922893289229','0001-01-01','Member',NULL,'1'),(7,'john the don','$2a$11$GSYV5Z0cTM4qogViMIYjAuGHFokXkSWG.Pa8m7ZHbcUnir.fU1cie','john@uiit.pa.com','john@gmail.com',NULL,'932382893828928','0001-01-01','Member',NULL,'1'),(8,'motu','$2a$11$5VLcbnHmi4ljfQppMWDaE.lhho6orh6VUs.Iz2wtPgW7ZzQJnw08y','motu@uiit.pa.com','motu@gmail.com',NULL,'11902812901','0001-01-01','Member',NULL,'1'),(9,'Inspector Chingum','$2a$11$xHgryu8aTua3LeMKztxieujGNtEXxEl81i5iCLLMZssH0b1Xzo6pe','inspector@uiit.pa.com','inspector@gmail.com',NULL,'922389283928','0001-01-01','Member',NULL,'1'),(10,'Genral Bajwa','$2a$11$e/JWWlv01qiX8P2mk3aSKuQs74nMRmVHoeuuZQm8u79vPGU2DJapO','bajwa@uiit.pa.com','bajwa@gmail.com',NULL,'11111111111','0001-01-01','Member',NULL,'1'),(11,'Imran kahn','$2a$11$0XaRj3ltUQ5bLo495ad1kenBjUhK9Cz8KrKOA4ARnA62RU7VuHSCK','khan@uiit.pa.com','khan@gmail.com',NULL,'11214121211','0001-01-01','Member',NULL,'1');
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

-- Dump completed on 2022-06-19 16:13:35

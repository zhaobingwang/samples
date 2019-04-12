/*
 Navicat Premium Data Transfer

 Source Server         : localhost
 Source Server Type    : MySQL
 Source Server Version : 80015
 Source Host           : localhost:3306
 Source Schema         : sample

 Target Server Type    : MySQL
 Target Server Version : 80015
 File Encoding         : 65001

 Date: 12/04/2019 14:11:53
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for StudentScores
-- ----------------------------
DROP TABLE IF EXISTS `StudentScores`;
CREATE TABLE `StudentScores`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `StuNumber` int(11) NOT NULL COMMENT '学生学号',
  `StuName` varchar(255) CHARACTER SET utf8 COLLATE utf8_czech_ci DEFAULT NULL COMMENT '学生姓名',
  `Course` varchar(255) CHARACTER SET utf8 COLLATE utf8_czech_ci DEFAULT NULL COMMENT '科目',
  `Score` decimal(4, 0) DEFAULT NULL COMMENT '分数',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_czech_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for Users
-- ----------------------------
DROP TABLE IF EXISTS `Users`;
CREATE TABLE `Users`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `NickName` varchar(24) CHARACTER SET utf8 COLLATE utf8_czech_ci DEFAULT NULL COMMENT '昵称',
  `Email` varchar(24) CHARACTER SET utf8 COLLATE utf8_czech_ci DEFAULT NULL COMMENT '邮箱地址',
  `IsDelete` tinyint(1) DEFAULT NULL COMMENT '是否已删除',
  `RegTime` datetime(0) DEFAULT NULL COMMENT '注册时间',
  `ModifyTime` datetime(0) DEFAULT NULL COMMENT '修改时间',
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_czech_ci DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 8 CHARACTER SET = utf8 COLLATE = utf8_czech_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for UsersFriends
-- ----------------------------
DROP TABLE IF EXISTS `UsersFriends`;
CREATE TABLE `UsersFriends`  (
  `Id` int(11) NOT NULL COMMENT '主键ID',
  `UserId` int(11) NOT NULL COMMENT '用户ID',
  `FriendId` int(11) NOT NULL COMMENT '好友ID',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for UsersTags
-- ----------------------------
DROP TABLE IF EXISTS `UsersTags`;
CREATE TABLE `UsersTags`  (
  `Id` bigint(11) NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `Name` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '标签名称',
  `UserId` int(11) NOT NULL COMMENT '用户ID',
  `FriendId` int(11) NOT NULL COMMENT '好友ID',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;

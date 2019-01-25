/*
 Navicat Premium Data Transfer

 Source Server         : localhost-3306
 Source Server Type    : MySQL
 Source Server Version : 50722
 Source Host           : localhost:3306
 Source Schema         : sample

 Target Server Type    : MySQL
 Target Server Version : 50722
 File Encoding         : 65001

 Date: 08/01/2019 21:20:07
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for student_scores
-- ----------------------------
DROP TABLE IF EXISTS `student_scores`;
CREATE TABLE `student_scores`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `StuNumber` int(11) NOT NULL COMMENT '学生学号',
  `StuName` varchar(255) CHARACTER SET utf8 COLLATE utf8_czech_ci NULL DEFAULT NULL COMMENT '学生姓名',
  `Course` varchar(255) CHARACTER SET utf8 COLLATE utf8_czech_ci NULL DEFAULT NULL COMMENT '科目',
  `Score` decimal(4, 0) NULL DEFAULT NULL COMMENT '分数',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 8 CHARACTER SET = utf8 COLLATE = utf8_czech_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;

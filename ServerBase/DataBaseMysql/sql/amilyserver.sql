/*
Navicat MySQL Data Transfer

Source Server         : 33server
Source Server Version : 50626
Source Host           : 10.1.1.33:3306
Source Database       : amilyserver

Target Server Type    : MYSQL
Target Server Version : 50626
File Encoding         : 65001

Date: 2015-08-19 14:31:58
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `reccount`
-- ----------------------------
DROP TABLE IF EXISTS `reccount`;
CREATE TABLE `reccount` (
  `RecodId` bigint(20) NOT NULL AUTO_INCREMENT,
  `RecordCount` bigint(20) NOT NULL,
  `RecordDt` datetime DEFAULT NULL,
  PRIMARY KEY (`RecodId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of reccount
-- ----------------------------

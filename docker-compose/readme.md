
# 开发环境搭建

## MySql
安装mysql时,将db/mysql/mysql-init.sql放到C:\docker\db\mysql中，其中的位置可以自己修改yml

- 安装
> docker-compose -f .\mysql.yml up -d

## 安装postgres

> docker-compose -f .\postgres.yml up -d
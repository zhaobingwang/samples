
# 1.行转列
# 数据表：student_scores
# 数据：
insert into student_scores(StuNumber,StuName,Course,Score) VALUES (10001,'张三','语文',74);
insert into student_scores(StuNumber,StuName,Course,Score) VALUES (10001,'张三','数学',83);
insert into student_scores(StuNumber,StuName,Course,Score) VALUES (10001,'张三','物理',93);
insert into student_scores(StuNumber,StuName,Course,Score) VALUES (10002,'李四','语文',74);
insert into student_scores(StuNumber,StuName,Course,Score) VALUES (10002,'李四','数学',84);
insert into student_scores(StuNumber,StuName,Course,Score) VALUES (10002,'李四','物理',94);
insert into student_scores(StuNumber,StuName,Course,Score) VALUES (10002,'李四','化学',73);

# 语句如下
SELECT StuName '姓名',
MAX(CASE Course WHEN '语文' THEN Score ELSE 0 END) '语文',
MAX(CASE Course WHEN '数学' THEN Score ELSE 0 END) '数学',
MAX(CASE Course WHEN '物理' THEN Score ELSE 0 END) '物理',
MAX(CASE Course WHEN '化学' THEN Score ELSE 0 END) '化学'
FROM student_scores
GROUP BY StuName;
# DaliyCostBook

一个简单的日常记账的H5应用

HTML界面基本全部使用weui来完成的

第一版是使用asp.net的风格完成的网络交互，后来有些地方觉得不爽，就把所有的前后端交互都改成ajax了

使用CYQ.DATA完成的数据库交互操作，建库脚本dbo.sql，这个脚本是sqlserver生成的


登录界面：
![登录界面](http://zhongzi.image.alimmdn.com/githubimg/Screenshot_2017-09-14-09-49-55.png@294w_522h_1l)



增加消费记录：前端H5获取GPS，通过百度地图api传入GPS坐标获取位置
http://api.map.baidu.com/geocoder/v2/?ak=ak=renderReverse&location=GPS坐标&output=json&pois=0&coordtype=wgs84ll
百度经纬度坐标和GPS经纬度坐标有偏移一定要加坐标类型
![增加消费记录](http://zhongzi.image.alimmdn.com/githubimg/Screenshot_2017-09-14-09-50-34.png@294w_522h_1l)



增加消费类型：
![增加消费类型](http://zhongzi.image.alimmdn.com/githubimg/Screenshot_2017-09-15-21-43-16.png@294w_522h_1l)



浏览：
![浏览](http://zhongzi.image.alimmdn.com/githubimg/Screenshot_2017-09-14-09-50-50.png@294w_522h_1l)




简单的统计：
![简单的统计](http://zhongzi.image.alimmdn.com/githubimg/Screenshot_2017-09-14-09-50-56.png@294w_522h_1l)

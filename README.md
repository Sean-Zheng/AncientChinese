# AncientChinese
书生文
=====
## 文件说明
    带{}的单词表示需要替换的文本
    {url}表示ip地址
### 文件相关接口
    {url}/api/file/get/{fileid}
    参数说明：
        fileid：文件的id
    结果类型：
        文件
### 字帖相关接口
    {url}/api/copybook/copybooklist
    参数说明：
        无
    结果类型：
        数组
    结果说明：
        {
            "Id": "c47c7b28-5514-4f80-91c1-f2f60d5f0c21",//字帖id
            "Title": "七发（简体）",//字帖名
            "BookType": "古文"//字帖类型
        }
        
        
    {url}/api/copybook/copybook/{id}
    参数说明：
        id：字帖的id
    结果类型：
        数组
    结果说明：
        文件的id

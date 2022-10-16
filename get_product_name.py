import random
from socket import getnameinfo
import string
from time import sleep
import requests
import multiprocessing

linkJson = "https://nanoreview.net/api/search?q=*&limit=600&type=laptop"
linkDetail = "https://nanoreview.net"
linkPost = "https://nanoreview.net/api/search/url"

def getName():
    respones = requests.get(linkJson)

    if respones.status_code == 200:
        json = respones.json()
        result = []
        for item in json:
            result.append(item['name'])
        return result
    return None

def getLink(name:str):
    fields = {"page1":name,"page2":name, "lang":"en"}
    boundary = '----WebKitFormBoundary' \
        + ''.join(random.sample(string.ascii_letters + string.digits, 16))
    body = (
        "".join("--%s\r\n"
                "Content-Disposition: form-data; name=\"%s\"\r\n"
                "\r\n"
                "%s\r\n" % (boundary, field, value)
                for field, value in fields.items()) +
        "--%s--\r\n" % boundary
    )
    post = requests.post(linkPost, body.encode('utf-8'), headers={"content-type":"multipart/form-data; boundary=%s" % boundary})
    try:
        json = post.json()
        if json['success']:
            open('./data.csv', 'a', encoding='utf-8').write(f'{name};;;{linkDetail + json["url"]}'+'\n')
    except:
        print(name)

if __name__ == '__main__':
    listProduct = getName()
    listProcess = []
    for name in listProduct:
        listProcess.append(multiprocessing.Process(target = getLink, kwargs = {"name": name}))

    index = 0
    maxProcess = 1
    lengthProcess = len(listProcess)

    while index < lengthProcess:
        while len(multiprocessing.active_children()) < maxProcess and index < lengthProcess:
            listProcess[index].start()
            index += 1
        sleep(0.1)

    while len(multiprocessing.active_children()) != 0:
        sleep(0.1)
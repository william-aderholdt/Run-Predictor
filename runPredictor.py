import requests
import json
from bs4 import BeautifulSoup

url = 'https://weather.com/weather/hourbyhour/l/58104:4:US'
#creates variable with url

r = requests.get(url)
#stores content from url in variable r.

soup = BeautifulSoup(r.content, 'html.parser')

rows = soup.select('tbody tr')
#Selects specific tags.

data = []

for row in rows:
    d = dict()

    d['time'] = row.select_one('.hourly-time').text.strip()
    d['temp'] = row.select_one('.temp').text.strip()
    d['feels'] = row.select_one('.feels').text.strip()
    d['precip'] = row.select_one('.precip').text.strip()
    d['wind'] = row.select_one('.wind').text.strip()
    #Gets the time, temperature, feeling, precipitation, and wind from each row.
    #Gives only the text between the tags.
    #Stripts all white space.

    data.append(d)
    
with open('weather.json', 'w') as f:
    json.dump(data, f)

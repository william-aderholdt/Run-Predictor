#Program written by William Aderholdt, started on December 16, 2018.

import requests
import os
from bs4 import BeautifulSoup

os.system('cls')

#Settings:
url = 'https://weather.com/weather/hourbyhour/l/58104:4:US'
tempMin = 30
tempMax = 80
windMax = 15
precipMax = 40

r = requests.get(url)
#Stores contents of html from url.

soup = BeautifulSoup(r.content, 'html.parser')
#Creates a nested data structure from the html.

rows = soup.select('tbody tr')
#Selects specific tags.

data = []
opt = []
#Create variables for holding data.


'''
Get the time, temperature, feeling, precipitation, and wind from each row in the table.  
Gives only the text between the tags. Strips all white space and degree icons. Appends 
to variable data.
'''
for row in rows:
   
    d = dict()

    d['time'] = row.select_one('.hourly-time').text.strip()
    d['temp'] = row.select_one('.temp').text.strip()
    d['feels'] = row.select_one('.feels').text.strip()
    d['precip'] = row.select_one('.precip').text.strip()
    d['wind'] = row.select_one('.wind').text.strip()

    d['temp'] = d['temp'][0:2]
    d['feels'] = d['feels'][0:2]
    d['precip'] = d['precip'][:-1]
    d['wind'] = d['wind'][-6:-4].replace(' ', '')
    #removes everything but the numbers for each.

    data.append(d)
    


'''
Iterates through each row checking temperature, precipitation, and wind against values in the settings.
Stores the optimal time row in a list(opt). 
'''
for i in range(0, len(data)):
    if (int(data[i]['temp']) >= tempMin and 
        int(data[i]['temp']) <= tempMax and 
        int(data[i]['precip']) <= precipMax and 
        int(data[i]['wind']) <= windMax):
        #Lined up for readability.
        opt.append(i)



'''
First, checks to see if variable opt is empty.  If it is empty, it returns no optimal times.  If it has
times, then prints to command line the rows which met the criteria of the settings.
'''
if not opt: 
    print('There are no optimal times to run for today.')
else:
    print('The following are the optimal times for you to run today:')

for j in opt:
    print("At %s, it will be %s degrees outside, and feel like it is %s degrees. There is a %s percent chance "
          "of precipitation. The wind will be %s mph." 
          % (data[j]['time'], data[j]['temp'], data[j]['feels'], data[j]['precip'], data[j]['wind']))
          #Arguments moved to next line for readability.


        
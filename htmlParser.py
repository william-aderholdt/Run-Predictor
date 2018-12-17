import requests
from bs4 import BeautifulSoup

url = 'https://weather.com/weather/hourbyhour/l/58104:4:US'
#creates variable with url

r = requests.get(url)
#stores content from url in variable r.

soup = BeautifulSoup(r.content, 'html.parser')

print(soup.prettify())
#prints a structured version of the DOM.
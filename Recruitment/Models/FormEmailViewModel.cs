﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recruitment.Models
{
    public class FormEmailViewModel
    {
        CANDIDATE candidate;
        string emailContent;
        string emailSubject;

        public CANDIDATE Candidate { get => candidate; set => candidate = value; }
        public string EmailContent { get => emailContent; set => emailContent = value; }
        public string EmailSubject { get => emailSubject; set => emailSubject = value; }

        public void InitializeAceTemplate(string picName) {
            string image = "<img style=\"width: 79.8375px; height: 49.5833px;\" src=\"data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAR0AAACxCAMAAADOHZloAAAA81BMVEX///8Dc9H7DQ0AAAD7AAAAb9AAa8+3ze0AcdAAbc9mm9yOs+Q9htYAZM37CAgAZs7Z2dnJycmRkZFFRUW4uLigoKCZmZn7JiZiYmL7MTH7Gxvg4OBoaGj7PDz7QEB5eXnQ0NBycnJSUlI+Pj729vYnJyfe3t6FhYWrq6v+vr7N3fP1+f3+zs6VlZU1NTVYWFjc5/b/8vL+4OD9kZH9mpp5puATExP8aGg0gtW+0+//6ur9jY3p8PqoxOrr6+vAwMD8WFj9r69RkNkcHBwlfNT9paWDrOL+0tL8d3f8TU2bu+f8goIAXMttn978Y2P+w8PEV31OWYRhAAANIUlEQVR4nO1dCXvauBYllkPsJMQsgdBAyhIIFCZAl2SgZUmTNNMmr5P3/3/N04JXvEhG16Tv8/m+mYbFuvKxdCRd3SsymRQpUqRIkSJFihQpUqRIkSLF/zE+bnn9cD4ZHCwWi4NdYCGFgmB8uJNRynAyOzrc+08uZ2STRO5GRuVDoKp/SStrODg6zmV1bS8haJq0qvvjm6qeyy1xdqMbCRFkHMituhdfVUVRP8sudXCTzSbAj3Ysu+Ie/MLsKOpX+QUfHBs6NDu5ufx6O/FKyFHUXxBlT26A+dGfIKrtwMmJQun5AFL68AmSH00HqbSNz7TpKMqJCmRgeJPbh2InCUlmUF+gbMzvDRh9BpfkO4sdRf0EZmWwB9K9chOwGlO82uQo6gWgoaec/OajQ8+SlRPFQc93QEsT6c1HywJWl+CLo+kQYd52NRqKQ0MuO1lgSf7oIgc3nr9BzS2k9i5tClpZlySv6fkH1N5A5toCWpL/8pKjqGewFud70qY+4JJ8vsGOon4BtvkoSZsTlmSTHlBhxjiWQ08W2CPoleQ1O3ewViXRAy7J//qyo6ivwHYzUwnaYyQuyeakB9Yuxt7WI5f+G7iKZwHsAK5GTQy3dapq2SFsDX8EkaPI9jH7YJLbjp3dSDLrWdCjFsZiq0WF9ghcvb+Dmw6cH8OB39sMXMYAtnL/BJPzA9ayicf40qMfAtctWJLvgC2b2EJ6jF1J8onagbVs4zkbk5zsM2zFPqonAewAbUz4ImbfApfknzvvVwQx+1Zud5KcwGBu4ybOuLUPLcnvAptOvM30+WQymcdRyji+MGhJ/h4syaJFDUnAjmEYWfLf9OZAcE97IS7M0JKcCZZksS2JydGjkdU16/lrejb3+CxEkPByVNsTqqI4AiX5RGh9tXj0C9DR9Ny9gGoeiDYe6Fnyp2BJFmg6z8GxOZpxz+97EWw8+/cx7lgEFxJUZ7YfqqdajjtsZGHoIoAO1gmUZIEFVnTMgP7IextPRyIA3t4LlmSFt+lMNI5pipabgd4GDF6Cm85PvhJmnPuZOeihVz6CJZl3F3TGPf03joBvRjreb+suHQisjYw/rPUESzLnHuhcKIbrD9OeYEnm9JcKOh2gB2CpCJZkzuiCJ8FFNbgrRiJCJFlRv3EUIO6Q0fR9SdChQ2+DJRmzw5NFchzD4aBJggGsYR9CyOGaCg4kB7YJkQy9wAqRZL40gGliSUWbgNb3b6FNh8MpONlh04HOhvgaRg5XVEosL7AcgCeo/QpnhyP9KO72kwTsVJK5RHm2O3bAsyHCJJkvBWCHHQtakj9HNB2OIO7t47XiYreSzDVkDXc2YoEnqG2EtHvZifa37052oBPUXiPI4YkteN6V7IBLshIqyQrXKus3WPJiBKCzISIkWeFy7sRZgcoAtCQHx0+KsLOjIWvnkqxwTZV3NGRBJ6gFhbT/EeyAZ0P4ZBn9OexAS7JvllEM3dkJO9AJahyS/HbZAU9QC8gy8rITPd/ZBTvQ2RA8kqxwzZW3CE2PizchyQrXOusw+bkytCQHZxl52Ileoye/znobkqxw+XcGSa/RwSU5OMvIy877yLIS9+9AS3JwSPsmPdGlJbwMBZfkwCwjH3aiJ8sJCw90zjCvJFN2ovez5ol2Leic4eAsIz92OGKbktwoBs8Z5pZkys5ddIHCcelb4A1JMqWHo8gEjy6FjooKzDIKYIcjMC5GRkxMQGdDhMRP+rPDE+iuJdR4oHOGOyKSTNnhCeCZJTRsQSeoBWYZBdPDk0t8KDzniRMiCB3nHBY/GcQOVzKxaN/Sfx/GACw5opJM2eE6LU4w6vRNhnOLSjKjh6to/jQJDAP6OPpYEJVkxg5fZt+Cn563mWUjLsmUHc5DTg84M5C0HHSqWSzEkGRGD+dBjJMsjxN1XwdeZMdEYOJnFDu8p3gOjyMzbTTjHnjOEhOxJJnRw33u/SIbPvHRdd5eNZkeuxHzrnkRS5LFGg/GU/CvRWi6QFbfoe7OhgDWqpAsI4mNB3evI91Xf/az+hF/p5q7R0DoOK+4kszYuROyNTt0HfSwp+3rWeNQaALo2SWD3sEKyzLioEf0/ODB0X3WoL/pYxi5vcNnQc+DJ/UCegcrIqQ9kp045wcPJwOMSZyIa7czFtxdGl+S1/RAnx/sgsedBu0u3UaS1/QkeHjT0H2YBrS7NCqknYed6F1RafBIMrS7NDzLiJOehA5jxAs2tyRDn+e1pSSb9CRykCfZmHdPJ6HdpdtK8podBbaWJjybh9DneYUmforQcwdbT4Yb93gFfZ6XBEk26eHJ3N8SHtEBz22UIckmPZA/Z0Ph9U9Dp5tHZhkJ0SPv9zF9MfceGwad2xiZZSSCE9iBa+jd+IFOpInOMno79Ay90b3QiTTyJDkBeh69fiFonxdHlpEwPUC/hjTcIAc6RFCqJFv0gBxEPd/cbIb2eZ3LlGQLEO6MyeYhl9AhglxZRnHokf5LbD5bhRrwAos7pF2cnjO5P1584xMABO3z4ssyikePzGnzfOqzCwbt8+LMMorLz50sb+GB7w4qtM+LM8soNj1yms/w3jesDtrnBSXJFk7U99vPDBeGf2jCHyvJNlT153bda/AYEMybBT4pViikfQt+XuLzMwk8rRra5yUY0r4VP/FG92Bu4H1eAllG2/Pzr7jbZxYW6wPt8xLJMpLBj/JFpAHNn7XQ0/GBfV5JSLILJ6p68YOPoPniODjGhwLa55WMJLuhqur5y2uERg+OphHUwPu8EpNkD3ALUs9+fvefBc1nz/ckriecmj34w2MiQ9pPtoEajfO7lx+vn1hPG84HB883x9kcDXmKxj6wz+sLR/0dcN65k8JzB86ceOfAhRPvTVxcvLvAH56d/3f6SDCdeoMkgzF9mxG7KVKkSJEiRYo3h2WrtXS+vqo3M5lWMeqy0zZCqH0qowbl0sP6r2arsUYr8qpafZXJVOoyKhCCIkLXztcFhG8ZXUZcVcLUtDBB1eCv9Ht8FVihrnmPp8hCZIJyHpUzmSrisxEbaIRuna+blJ1S+EUlNCbV75RQcCPjrXkFNc0/T1Gf75pMQuwUULmF8o43eNg5tT4Pech1zpqXkdWzT8kdcyIRdlpouUIN9nf5FqGixU6/lLnGTZw2jjzuSY4OWLIed791hf+/usQdjbxVKxWaI4TGy8yy1EVt0rdOyWtCf7OUX9msF3CJI9JSSiNUMt91slMrtamBNnmrgs1XKYlWcQ52LPNLyzy1hy1QYVzWEXrg590BUl/EnkAPdStF1DXZKaISui53UYXUpFspj5Elgcj9yK7xx9e3pFdcoTZqlKuom1m2u2iM2WmgURlL24q00h6yiuijh0rlkrzsjVHDVChXz+ohLM1LaqqNxmV88dJZnM2Obb5mmSdl3VYqD+xd1MO1jxALP/TJ5S1iDRdCru8gm50ufT0yH1HL7AI1t2jnEX3KXdzJcEXy9G5q655VYHyQeyzQkhmWpFTylZWnZ1UrFMU8LbCZGZHy+ojQt8L/dxRnseM238R/jrH5Dnowv/lADRQFNM3EJbmFJh16ekx+yjY7BfJ6hMjdkv7Taa415orVx8SatVN8YY3VvkwupeyMmS718RsFZA/T67KXaEx6Tc1mxwS5kxpuX7Rjj1ghpZZZHCnfYsfffJmRUR51CqT1E6JcleYBboq1fP6Kausl6y5Nm52ayR+u9bhsS/fS3UofUIGgj++kxsSpb7GDHyb5rIxvpWA3HUw3+5cMly52Kp01yEusNrSRsoaWcRdnseNvvmWVWkEV8nnzQVjBi45ndcuuztvsLE12Ms0q+VLFrqT5V6HXzFgPvIGrV/Gys0bRxc4I2QW52HFpJ+vl+B9rVuUozmLH3/zYGkx71hdE2Vk/iz55RqONtmOzQ1grP1i3d2nNAcao6dToTXYerM+c7JRMdkZh7LTZrLBj9wlHcQ52/MxXLTUr2vMpMRTQerQg40GLlXLtw06LDYzmt7H5tlmdW8IQ/WK+1dxk55I9wmYr72KnwWw1yVwikB0sxmwKsL7/26pZXAEXZ7FT9TVfpCMNbjid1brNNyoZMdTNNlDEJTQ3xiyLHVa9gl33LlPY2i2hYcW0cEQHDQ87fTaXukXutsNsMbV3seMYV+hgPibvXFPDRGzY6EWLs9jxN8/G1SUZd9mM9Vp0zOpYa4grUpMGne9UzXXWWpVHVJVvi3hKbTfhThfrdKvExhbc6i7xheS6KyaLdMzq4XfJ7bXJZwXCjmsy072ujOi9XvuNWZi2EbmoQ2c5XVQv12mvsouz5zu2+ZppfkWqPyLvNulUolhpCw9ZhZb1NBtkoV7GtSp3zDX6aZ22nR5pJWQ2ihrORUOfvNNa31e/a05W67TEVR23yU51RG4ey9V6clsvOK/Hc9pL+uW1HQLHGn1ZYH6CFf2HKCvr1lZxjjW613yBmM+ckidIZiKZqzFC3Vhz5RQpUqRIkSJFihQpUqRIkQIS/wM+8m0bdmwJeQAAAABJRU5ErkJggg==\" data-filename=\"logoAce.png\">";

            string result =
                "<p>Hi <span style=\"font-weight: bold;\">" + candidate.NAMA_LENGKAP + "</span></p><p>First of all thank you for your trust and intention by applying to our company​. It is a pleasure to know your interest for the position of <span style=\"font-weight: bold;\">" + candidate.JUDUL_POSISI + "</span>,<br><br>So, We hereby would like to invite you for the Interview to <span style=\"font-weight: bold;\">%NamaPerusahaan%</span> with detail :<br>Date : <span style=\"font-weight: bold;\">​%InterviewDate%</span><br>Time : <span style=\"font-weight: bold;\">%InterviewTime%</span> (about 1 hour)<br>Location : <span style=\"font-weight: bold;\">​​​%AlamatClient%</span><br>Google Maps : <br>Interviewer : ​<span style=\"font-weight: bold;\">Ibu Rissa or HRD Team</span><br><br><b>*Please come 15 minutes before the schedule and bring along your Updated CV</b><br><br>For your confirmation, Please reply to this email.<br>Looking forward to hear from you soon</p><p><br><br><span style=\"font-weight: bold;\">" + picName + "</span><br>HR Specialist<br>"+image+"<br><span style=\"font-weight: bold;\"><span style=\"font-family: &quot;Comic Sans MS&quot;;\">PT. ACE -&nbsp;<span style=\"color: rgb(0, 0, 255);\">Adicipta&nbsp;</span><span style=\"color: rgb(255, 0, 0);\">Carsani&nbsp;</span>Ekakarya</span></span><br><span style=\"color: rgb(99, 99, 99);\"><span style=\"background-color: inherit;\">Phone:&nbsp;(021) 536 7 3030&nbsp;Fax:&nbsp;(021) 536 0808</span></span> <br>HP:&nbsp;<span style=\"color: rgb(57, 132, 198);\">+6282111948439</span><br></p>";
            emailContent = result;
        }
    }
}
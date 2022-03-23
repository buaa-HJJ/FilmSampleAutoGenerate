# -*- coding: utf-8 -*-
"""
Created on Mon Feb 28 22:01:08 2022

@author: 2019-1903
"""

from pyDOE import *
import numpy as np

sam = 32
n = 6

a = lhs(n, samples=sam, criterion='center')

#  定义参数初始值和范围
# （气膜孔直径、倾角、流向间距、展向间距、外壁厚度、冲击距离）
Ini = np.array([0.4, 20, 3, 3, 0.7, 0.7])
ran = np.array([0.5, 50, 10, 2, 0.5, 0.5])

data = np.zeros((sam, n))

for i in range(sam):
    data[i, :] = Ini + ran*a[i, :]

# 写文件
filename = 'lhsData.csv'
np.savetxt(filename, data, fmt='%0.2f', delimiter=',')
filename = 'lhsData.txt'
np.savetxt(filename, data, fmt='%0.2f', delimiter=',')


modelList = open(
    r'D:\FILES\Project\20220227-FilmSampleAutoGenerate\01-model\modelList.txt', 'w')
with open(r'D:\FILES\Project\20220227-FilmSampleAutoGenerate\00-DataDesign\lhsData.txt', 'r') as f:
    lines = f.readlines()
    for line in lines:
        line_new = line.replace('\n', '')
        line_new = r'{' + line_new + r'}' + ',' + '\n'
        modelList.write(line_new)
modelList.close()

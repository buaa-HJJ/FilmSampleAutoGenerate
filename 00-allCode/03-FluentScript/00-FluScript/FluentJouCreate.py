# encoding: utf-8


# API
dataPath = r"D:\FILES\Project\20220227-FilmSampleAutoGenerate\00-DataDesign\lhsData.csv"
ScScriptPath = r"D:\FILES\Project\20220227-FilmSampleAutoGenerate\02-spaceClaim\NSAutoCreateByRay.txt"
FluScriptPath = r"D:\FILES\Project\20220227-FilmSampleAutoGenerate\03-Fluent\00-FluScript\FluentBCSet.txt"

# Fluent
def fluentJouCreate(FluScriptPath, exportPath, Df, Pc, BR, inletU, inletTm, inletTc):
    with open(FluScriptPath,"r") as f:
        lines = f.readlines()

        fields = lines[1].split('\"')
        fields[3] = str(Df)+" [mm]"
        lines[1] = '\"'.join(fields)

        fields = lines[2].split('\"')
        fields[3] = str(Pc)+" [mm]"
        lines[2] = '\"'.join(fields)

        fields = lines[3].split('\"')
        fields[3] = str(BR)
        lines[3] = '\"'.join(fields)

        fields = lines[4].split('\"')
        fields[3] = str(inletU)+" [m s^-1]"
        lines[4] = '\"'.join(fields)

        fields = lines[5].split('\"')
        fields[3] = str(inletTm)+" [K]"
        lines[5] = '\"'.join(fields)

        fields = lines[6].split('\"')
        fields[3] = str(inletTc)+" [K]"
        lines[6] = '\"'.join(fields)

        fields = lines[9].split('\"')
        fields[1] = exportPath    #传入cas导出地址
        lines[9] = '\"'.join(fields)

    with open(exportPath,"w") as f:
        f.writelines(lines)
            



# main

#import data
with open(dataPath,"r") as f:
    lines = f.readlines()

flag = 1
for line in lines:
    BR = 0.75
    inletU = 40
    inletTm = 1700
    inletTc = 1050

    num = line.split(',') 
    modelID = num[0] + "-" + num[1] + "-" + num[2] + "-" + num[3] + "-" + num[4] + "-" + num[5]
    cfdConditions = str(BR) + "-" + str(inletU) + "-" + str(inletTm) + "-" + str(inletTc)
    modelPath = "D:/FILES/Project/20220227-FilmSampleAutoGenerate/01-model/" + modelID + ".prt"
    exportPath = r"D:\FILES\Project\20220227-FilmSampleAutoGenerate\03-Fluent\02-FluData\ID" + str(flag) + "-" + "solveSet-" + cfdConditions + ".jou"
    modelPath = modelPath.replace('\n', '')
    exportPath = exportPath.replace('\n', '')

    Df = float(num[0])
    Sc = float(num[2])
    Pc = float(num[3])
    ThiOut = float(num[4])
    H = float(num[5])

    flag = flag + 1

    fluentJouCreate(FluScriptPath, exportPath, Df, Pc, BR, inletU, inletTm, inletTc)

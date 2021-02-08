_row=1
while   _row<=9:
    _col=1
    while _col<=_row:
        print(f"{_col}*{_row}={_row*_col}",end="\t")
        _col+=1
    _row+=1
    print("\n")
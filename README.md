# RetroCheatEdit
RetroArchやJohn Emurator(Android) snes9xのchtファイルの編集を行うエディタです。<br>
<br>
RetroArchやJohn Emurator Snex9Xの相互変換等の用途に使います。<br>
<br>

今現在以下のチートファイルに対応しています。

* John Emulator (NES/GB) *.cht
* RetroArch *.cht
* Snes9X *.cht
* ppsspp *.ini
* DraStic *.cht

<br>
オマケで簡易C#コンソールをつけてあります。<br>
面倒な計算をC#で出来ます。<br>
<br>
演算結果は以下の関数で下のテキストボックスに出力させます。

* write()<br> 変数を下のテキストボックスへ出力
* writeln()<br> 改行付き
* cls()<br> 画面消去
* IntToHex()<br>  Integerを１６審文字列へ
* HexToInt()<br> 16進文字列をIntegerへ

# 例
ドラクエのキャラ４人分の改造コードを作るコードは以下の感じ。<br>
http://freedomborokabu.blog72.fc2.com/blog-entry-72.html
<br>を参照です。

```
// ドラクエ３のキャラの最大HPを４人999

int adr1 = 0x7E3929; // 一人目のアドレス
int adr2 = 0x7E392A;

string ret = "";
for(int i=0; i<4;i++)
{
    int a1 = adr1 + 0x3c*i;
    int a2 = adr2 + 0x3c*i;

    ret += $"{IntToHex6(a1).ToUpper()}E7\r\n";
    ret += $"{IntToHex6(a2).ToUpper()}03\r\n";

}
cls();
writeln(ret);
```
で実行すると以下のコードが作成されます。
```
7E3929E7
7E392A03
7E3965E7
7E396603
7E39A1E7
7E39A203
7E39DDE7
7E39DE03
```
## License
This software is released under the MIT License, see LICENSE.

## Authors

bry-ful(Hiroshi Furuhashi) <br>
twitter:[bryful](https://twitter.com/bryful) <br>
bryful@gmail.com <br>

# References

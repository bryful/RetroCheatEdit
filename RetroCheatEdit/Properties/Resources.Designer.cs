﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace RetroCheatEdit.Properties {
    using System;
    
    
    /// <summary>
    ///   ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    /// </summary>
    // このクラスは StronglyTypedResourceBuilder クラスが ResGen
    // または Visual Studio のようなツールを使用して自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    // ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("RetroCheatEdit.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   すべてについて、現在のスレッドの CurrentUICulture プロパティをオーバーライドします
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   /*
        ///    コードを作成するサンプル
        ///*/
        ///string s = &quot;&quot;;
        ///for (int i= 0x7E1A00; i&lt;=0x7E1A87;i++)
        ///{
        ///    s += IntToHex(i).ToUpper() + &quot;FF\r\n&quot;;   
        ///}
        ///cls();      // 画面消去
        ///writeln(s); // 画面に表示 に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string sampleCode1 {
            get {
                return ResourceManager.GetString("sampleCode1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   /*
        ///    Wiardry の種族職業性格の値を計算
        ///*/
        ///enum RACE{
        ///Human = 0x00,Elf = 0x20,Dworf = 0x40,Gnorm = 0x60,Hob = 0x80
        ///}
        ///enum Job{
        ///Fig = 0x00,Mag = 0x04,Pri = 0x08,Trf = 0x0C,Bis = 0x10,Sam = 0x14,Load = 0x18,Nin = 0x1C
        ///}
        ///enum Ali{
        ///G = 0x00,N = 0x01,E = 0x02
        ///}
        ///
        ///int v = (int)RACE.Human + (int)Job.Sam + (int)Ali.G;
        ///cls();
        ///writeln(&quot;人間・サムライ・善 : &quot; + IntToHex(v)); に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string SampleCode2 {
            get {
                return ResourceManager.GetString("SampleCode2", resourceCulture);
            }
        }
    }
}

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
namespace base64;

public class Base64 {
    string Table;
    string PaddingSymbol;
    public Base64(string padding_sym = "=", string custom_table = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/") {
        this.Table = custom_table;
        this.PaddingSymbol = padding_sym;
    }
    public string Encode(string data) {

        string encoded = "";
        string bins = string2bin(data);
        var chunk_size = 6;
        var chunks = bins.Select((v, i) => new { v, i })
            .GroupBy(x => x.i / chunk_size)
            .Select(g => g.Select(x => x.v));

        foreach(var chunk in chunks) {
            var index_value = String.Join("",chunk);
            if(index_value.Length != chunk_size) {
                index_value = index_value.PadRight(chunk_size, '0');
            }
            int index = Convert.ToInt32(index_value, 2);
            encoded += this.Table[index];
        }

        const int encodedChunkSize = 4;
        var mod = encoded.Length % encodedChunkSize;
        if(mod == 0)
            return encoded;

        var padding_count = encodedChunkSize - mod;
        for(int i = 0; i < padding_count; i++)
            encoded += this.PaddingSymbol;    
        
        return encoded;
    }

    public string Decode(string data) {
        string decoded = "";
        string trimed_data = data.Replace(this.PaddingSymbol, "");
        string bins = "";
        foreach(var d in trimed_data) {
            int index = this.Table.IndexOf(d);
            string bin = Convert.ToString(index, 2).PadLeft(6, '0');
            bins += bin;
        } 
        MatchCollection ms = Regex.Matches(bins, ".{8}");
        foreach(var m in ms) {
            string bin = String.Join("",m.ToString());
            decoded += (char)Convert.ToInt32(bin, 2);
        }
        return decoded;
    }

    private string string2bin(string data) {
        byte[] bytes = Encoding.ASCII.GetBytes(data);
        IEnumerable<string> bins = bytes.Select(b => Convert.ToString(b, 2).PadLeft(8, '0'));
        string bins_joined = String.Join("", bins);
        return bins_joined;
    }
}
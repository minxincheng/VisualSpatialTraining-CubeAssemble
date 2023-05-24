using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReadWriteCSV;
using System.IO;
using UnityEngine.Networking;

public class DataHandler : MonoBehaviour
{
    
    List<ContinuousData> continuousDatas = new List<ContinuousData>();
    HeaderData headerData;
    
    private string pid;
    private string hand;
    
    public bool dataWritten = false;
    
    void OnDisable(){
        
        WriteContinuousFile();
        
    }
    
    public void WriteDataToFiles(){
        
        if(dataWritten){
            
            Debug.Log("Data already saved");
            return;
            
        }
        
        dataWritten = true;
        
        System.DateTime now = System.DateTime.Now;
        
        if(GlobalControl.Instance.handOption == 0){
            
            hand = "Right";
            
        }
        else{
            
            hand = "Left";
            
        }
        
        pid = GlobalControl.Instance.participantID + "_" + now.Month.ToString() + "_" + now.Day.ToString() + "_" + now.Hour + "_" + now.Minute;
        
        if(GlobalControl.Instance.recordingData){
            
            WriteContinuousFile();
            
        }
        
    }
    
    public void recordHeaderInfo(string hand, string v1, string v2, string v3, string v4, string left, string right){
        
        headerData = new HeaderData(hand, v1, v2, v3, v4, left, right);
        
    }
    
    public void recordContinuous(float time, int submitting, int checking, string v1, string v2, string v3, string v4, string left, string right, string draging, int v1correct, int v2correct, int v3correct, int v4correct, int leftcorrect, int rightcorrect, Vector3 handPos){
        
        continuousDatas.Add(new ContinuousData(time, submitting, checking, v1, v2, v3, v4, left, right, draging, v1correct, v2correct, v3correct, v4correct, leftcorrect, rightcorrect, handPos));
        
    }
    
    private void WriteHeaderInfo(CsvFileWriter writer){
        
        CsvRow hand = new CsvRow();
        hand.Add("Hand:");
        hand.Add(headerData.hand.ToString());
        
        CsvRow v1 = new CsvRow();
        v1.Add("V1:");
        v1.Add(headerData.v1.ToString());
        
        CsvRow v2 = new CsvRow();
        v2.Add("V2:");
        v2.Add(headerData.v2.ToString());
        
        CsvRow v3 = new CsvRow();
        v3.Add("V3:");
        v3.Add(headerData.v3.ToString());
        
        CsvRow v4 = new CsvRow();
        v4.Add("V4:");
        v4.Add(headerData.v4.ToString());
        
        CsvRow left = new CsvRow();
        left.Add("Left:");
        left.Add(headerData.left.ToString());
        
        CsvRow right = new CsvRow();
        right.Add("Right:");
        right.Add(headerData.right.ToString());
        
        writer.WriteRow(hand);
        writer.WriteRow(v1);
        writer.WriteRow(v2);
        writer.WriteRow(v3);
        writer.WriteRow(v4);
        writer.WriteRow(left);
        writer.WriteRow(right);
        
    }
    
    private void WriteContinuousFile(){
        
        string directory = "Data/" + pid;
        Directory.CreateDirectory(@directory);
        
        using(CsvFileWriter writer = new CsvFileWriter(@directory + "/" + pid + "_Continuous.csv")){
            
            Debug.Log("Writing continuous data to file");
            
            WriteHeaderInfo(writer);
            
            CsvRow header = new CsvRow();
            header.Add("ID");
            header.Add("Timestamp");
            header.Add("isSubmitting");
            header.Add("isCheckingCube");
            header.Add("CurrentV1");
            header.Add("CurrentV2");
            header.Add("CurrentV3");
            header.Add("CurrentV4");
            header.Add("CurrentLeft");
            header.Add("CurrentRight");
            header.Add("Draging");
            header.Add("isV1Correct");
            header.Add("isV2Correct");
            header.Add("isV3Correct");
            header.Add("isV4Correct");
            header.Add("isLeftCorrect");
            header.Add("isRightCorrect");
            header.Add("HandPosX");
            header.Add("HandPosY");
            
            writer.WriteRow(header);
            
            // write each line of data
            foreach(ContinuousData c in continuousDatas){
                
                CsvRow row = new CsvRow();
                row.Add(GlobalControl.Instance.participantID);
                row.Add(c.time.ToString());
                row.Add(c.submitting.ToString());
                row.Add(c.checking.ToString());
                row.Add(c.v1.ToString());
                row.Add(c.v2.ToString());
                row.Add(c.v3.ToString());
                row.Add(c.v4.ToString());
                row.Add(c.left.ToString());
                row.Add(c.right.ToString());
                row.Add(c.draging.ToString());
                row.Add(c.v1correct.ToString());
                row.Add(c.v2correct.ToString());
                row.Add(c.v3correct.ToString());
                row.Add(c.v4correct.ToString());
                row.Add(c.leftcorrect.ToString());
                row.Add(c.rightcorrect.ToString());
                row.Add(c.handPos.x.ToString());
                row.Add(c.handPos.y.ToString());
                
                writer.WriteRow(row);

            }
            
            
        }
        
    }
}

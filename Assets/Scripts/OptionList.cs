using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionList : MonoBehaviour
{
    // get the current option name for game controller,
    // spawn the object to cube accordingly
    public string name;
    // the shape that needs to be spawned
    public GameObject face;
    // the relative position that should spawn
    public Vector3 relativePos;
    // the original that should be moved back
    public float row, col;
    
    // float values for the options position and the relative shape position
    private float row1, row2, row3, row4, row5;
    public float col1, col2, col3, col4, col5, col6;
    private Vector3 c, tl, tr, bl, br;
    
    // all the shapes
    public GameObject option, df, dnf, sf, snf, pf, pnf;
    
    void Start(){
        
        face = null;
        
    }
    
    public void Greet(string name){
        
        switch(name){
            
            case string n when name.Contains("df"):
                face = df;
                break;
            case string n when name.Contains("dnf"):
                face = dnf;
                break;
            case string n when name.Contains("sf"):
                face = sf;
                break;
            case string n when name.Contains("snf"):
                face = snf;
                break;
            case string n when name.Contains("pf"):
                face = pf;
                break;
            case string n when name.Contains("pnf"):
                face = pnf;
                break;
            default:
                face = null;
                break;
            
        }
        
        switch(name){
            
            case string n when name.Contains("tl"):
                relativePos = new Vector3(-0.0035f, 0.0035f, -0.0004f);
                break;
            case string n when name.Contains("tr"):
                relativePos = new Vector3(0.0035f, 0.0035f, -0.0004f);
                break;
            case string n when name.Contains("bl"):
                relativePos = new Vector3(-0.0035f, -0.0035f, -0.0004f);
                break;
            case string n when name.Contains("br"):
                relativePos = new Vector3(0.0035f, -0.0035f, -0.0004f);
                break;
            default:
                relativePos = new Vector3(0, 0, 0);
                break;
            
        }
        
    }
    
    public void Initialize(){

        // assign values to the options position

        if (GlobalControl.Instance.handOption == 0)
        {
            col1 = 0f;
            col2 = 0.075f;
            col3 = 0.15f;
            col4 = 0.225f;
            col5 = 0.3f;
            col6 = 0.375f;

            row1 = 0.15f;
            row2 = 0.075f;
            row3 = 0f;
            row4 = -0.075f;
            row5 = -0.15f;

        }
        else
        {
            col1 = 0f;
            col2 = -0.075f;
            col3 = -0.15f;
            col4 = -0.225f;
            col5 = -0.3f;
            col6 = -0.375f;

            row1 = 0.15f;
            row2 = 0.075f;
            row3 = 0f;
            row4 = -0.075f;
            row5 = -0.15f;
        }

        
        // relative shape position
        tl = new Vector3(-0.02f, 0.02f, -0.0006f);
        tr = new Vector3(0.02f, 0.02f, -0.0006f);
        bl = new Vector3(-0.02f, -0.02f, -0.0006f);
        br = new Vector3(0.02f, -0.02f, -0.0006f);
        
        // column 1: dot filled (df)
        GameObject df_c = Instantiate(option, new Vector3(col1, row1, 0), Quaternion.identity);
        df_c.name = "df_c";
        GameObject dfc = Instantiate(df, new Vector3(col1, row1, 0), Quaternion.identity);
        dfc.transform.SetParent(df_c.transform);
        Destroy(dfc.GetComponent<MeshCollider>());

        GameObject df_tl = Instantiate(option, new Vector3(col1, row2, 0), Quaternion.identity);
        df_tl.name = "df_tl";
        GameObject dftl = Instantiate(df, new Vector3(col1, row2, 0) + tl, Quaternion.identity);
        dftl.transform.SetParent(df_tl.transform);
        Destroy(dftl.GetComponent<MeshCollider>());
        
        GameObject df_tr = Instantiate(option, new Vector3(col1, row3, 0), Quaternion.identity);
        df_tr.name = "df_tr";
        GameObject dftr = Instantiate(df, new Vector3(col1, row3, 0) + tr, Quaternion.identity);
        dftr.transform.SetParent(df_tr.transform);
        Destroy(dftr.GetComponent<MeshCollider>());
        
        GameObject df_bl = Instantiate(option, new Vector3(col1, row4, 0), Quaternion.identity);
        df_bl.name = "df_bl";
        GameObject dfbl = Instantiate(df, new Vector3(col1, row4, 0) + bl, Quaternion.identity);
        dfbl.transform.SetParent(df_bl.transform);
        Destroy(dfbl.GetComponent<MeshCollider>());
        
        GameObject df_br = Instantiate(option, new Vector3(col1, row5, 0), Quaternion.identity);
        df_br.name = "df_br";
        GameObject dfbr = Instantiate(df, new Vector3(col1, row5, 0) + br, Quaternion.identity);
        dfbr.transform.SetParent(df_br.transform);
        Destroy(dfbr.GetComponent<MeshCollider>());
        
        // column 2: dot not filled (dnf)
        GameObject dnf_c = Instantiate(option, new Vector3(col2, row1, 0), Quaternion.identity);
        dnf_c.name = "dnf_c";
        GameObject dnfc = Instantiate(dnf, new Vector3(col2, row1, 0), Quaternion.identity);
        dnfc.transform.SetParent(dnf_c.transform);
        Destroy(dnfc.GetComponent<MeshCollider>());
        
        GameObject dnf_tl = Instantiate(option, new Vector3(col2, row2, 0), Quaternion.identity);
        dnf_tl.name = "dnf_tl";
        GameObject dnftl = Instantiate(dnf, new Vector3(col2, row2, 0) + tl, Quaternion.identity);
        dnftl.transform.SetParent(dnf_tl.transform);
        Destroy(dnftl.GetComponent<MeshCollider>());
        
        GameObject dnf_tr = Instantiate(option, new Vector3(col2, row3, 0), Quaternion.identity);
        dnf_tr.name = "dnf_tr";
        GameObject dnftr = Instantiate(dnf, new Vector3(col2, row3, 0) + tr, Quaternion.identity);
        dnftr.transform.SetParent(dnf_tr.transform);
        Destroy(dnftr.GetComponent<MeshCollider>());
        
        GameObject dnf_bl = Instantiate(option, new Vector3(col2, row4, 0), Quaternion.identity);
        dnf_bl.name = "dnf_bl";
        GameObject dnfbl = Instantiate(dnf, new Vector3(col2, row4, 0) + bl, Quaternion.identity);
        dnfbl.transform.SetParent(dnf_bl.transform);
        Destroy(dnfbl.GetComponent<MeshCollider>());
        
        GameObject dnf_br = Instantiate(option, new Vector3(col2, row5, 0), Quaternion.identity);
        dnf_br.name = "dnf_br";
        GameObject dnfbr = Instantiate(dnf, new Vector3(col2, row5, 0) + br, Quaternion.identity);
        dnfbr.transform.SetParent(dnf_br.transform);
        Destroy(dnfbr.GetComponent<MeshCollider>());
        
        // column 3: square filled (sf)
        GameObject sf_c = Instantiate(option, new Vector3(col3, row1, 0), Quaternion.identity);
        sf_c.name = "sf_c";
        GameObject sfc = Instantiate(sf, new Vector3(col3, row1, 0), Quaternion.identity);
        sfc.transform.SetParent(sf_c.transform);
        Destroy(sfc.GetComponent<MeshCollider>());
        
        GameObject sf_tl = Instantiate(option, new Vector3(col3, row2, 0), Quaternion.identity);
        sf_tl.name = "sf_tl";
        GameObject sftl = Instantiate(sf, new Vector3(col3, row2, 0) + tl, Quaternion.identity);
        sftl.transform.SetParent(sf_tl.transform);
        Destroy(sftl.GetComponent<MeshCollider>());
        
        GameObject sf_tr = Instantiate(option, new Vector3(col3, row3, 0), Quaternion.identity);
        sf_tr.name = "sf_tr";
        GameObject sftr = Instantiate(sf, new Vector3(col3, row3, 0) + tr, Quaternion.identity);
        sftr.transform.SetParent(sf_tr.transform);
        Destroy(sftr.GetComponent<MeshCollider>());
        
        GameObject sf_bl = Instantiate(option, new Vector3(col3, row4, 0), Quaternion.identity);
        sf_bl.name = "sf_bl";
        GameObject sfbl = Instantiate(sf, new Vector3(col3, row4, 0) + bl, Quaternion.identity);
        sfbl.transform.SetParent(sf_bl.transform);
        Destroy(sfbl.GetComponent<MeshCollider>());
        
        GameObject sf_br = Instantiate(option, new Vector3(col3, row5, 0), Quaternion.identity);
        sf_br.name = "sf_br";
        GameObject sfbr = Instantiate(sf, new Vector3(col3, row5, 0) + br, Quaternion.identity);
        sfbr.transform.SetParent(sf_br.transform);
        Destroy(sfbr.GetComponent<MeshCollider>());
        
        // column 4: square not filled (snf)
        GameObject snf_c = Instantiate(option, new Vector3(col4, row1, 0), Quaternion.identity);
        snf_c.name = "snf_c";
        GameObject snfc = Instantiate(snf, new Vector3(col4, row1, 0), Quaternion.identity);
        snfc.transform.SetParent(snf_c.transform);
        Destroy(snfc.GetComponent<MeshCollider>());
        
        GameObject snf_tl = Instantiate(option, new Vector3(col4, row2, 0), Quaternion.identity);
        snf_tl.name = "snf_tl";
        GameObject snftl = Instantiate(snf, new Vector3(col4, row2, 0) + tl, Quaternion.identity);
        snftl.transform.SetParent(snf_tl.transform);
        Destroy(snftl.GetComponent<MeshCollider>());
        
        GameObject snf_tr = Instantiate(option, new Vector3(col4, row3, 0), Quaternion.identity);
        snf_tr.name = "snf_tr";
        GameObject snftr = Instantiate(snf, new Vector3(col4, row3, 0) + tr, Quaternion.identity);
        snftr.transform.SetParent(snf_tr.transform);
        Destroy(snftr.GetComponent<MeshCollider>());
        
        GameObject snf_bl = Instantiate(option, new Vector3(col4, row4, 0), Quaternion.identity);
        snf_bl.name = "snf_bl";
        GameObject snfbl = Instantiate(snf, new Vector3(col4, row4, 0) + bl, Quaternion.identity);
        snfbl.transform.SetParent(snf_bl.transform);
        Destroy(snfbl.GetComponent<MeshCollider>());
        
        GameObject snf_br = Instantiate(option, new Vector3(col4, row5, 0), Quaternion.identity);
        snf_br.name = "snf_br";
        GameObject snfbr = Instantiate(snf, new Vector3(col4, row5, 0) + br, Quaternion.identity);
        snfbr.transform.SetParent(snf_br.transform);
        Destroy(snfbr.GetComponent<MeshCollider>());
        
        // column 5: cross filled (cf)
        GameObject pf_c = Instantiate(option, new Vector3(col5, row1, 0), Quaternion.identity);
        pf_c.name = "pf_c";
        GameObject pfc = Instantiate(pf, new Vector3(col5, row1, 0), Quaternion.identity);
        pfc.transform.SetParent(pf_c.transform);
        Destroy(pfc.GetComponent<MeshCollider>());
        
        GameObject pf_tl = Instantiate(option, new Vector3(col5, row2, 0), Quaternion.identity);
        pf_tl.name = "pf_tl";
        GameObject pftl = Instantiate(pf, new Vector3(col5, row2, 0) + tl, Quaternion.identity);
        pftl.transform.SetParent(pf_tl.transform);
        Destroy(pftl.GetComponent<MeshCollider>());
        
        GameObject pf_tr = Instantiate(option, new Vector3(col5, row3, 0), Quaternion.identity);
        pf_tr.name = "pf_tr";
        GameObject pftr = Instantiate(pf, new Vector3(col5, row3, 0) + tr, Quaternion.identity);
        pftr.transform.SetParent(pf_tr.transform);
        Destroy(pftr.GetComponent<MeshCollider>());
        
        GameObject pf_bl = Instantiate(option, new Vector3(col5, row4, 0), Quaternion.identity);
        pf_bl.name = "pf_bl";
        GameObject pfbl = Instantiate(pf, new Vector3(col5, row4, 0) + bl, Quaternion.identity);
        pfbl.transform.SetParent(pf_bl.transform);
        Destroy(pfbl.GetComponent<MeshCollider>());
        
        GameObject pf_br = Instantiate(option, new Vector3(col5, row5, 0), Quaternion.identity);
        pf_br.name = "pf_br";
        GameObject pfbr = Instantiate(pf, new Vector3(col5, row5, 0) + br, Quaternion.identity);
        pfbr.transform.SetParent(pf_br.transform);
        Destroy(pfbr.GetComponent<MeshCollider>());
        
        // column 6: cross not filled (cnf)
        GameObject pnf_c = Instantiate(option, new Vector3(col6, row1, 0), Quaternion.identity);
        pnf_c.name = "pnf_c";
        GameObject pnfc = Instantiate(pnf, new Vector3(col6, row1, 0), Quaternion.identity);
        pnfc.transform.SetParent(pnf_c.transform);
        Destroy(pnfc.GetComponent<MeshCollider>());
        
        GameObject pnf_tl = Instantiate(option, new Vector3(col6, row2, 0), Quaternion.identity);
        pnf_tl.name = "pnf_tl";
        GameObject pnftl = Instantiate(pnf, new Vector3(col6, row2, 0) + tl, Quaternion.identity);
        pnftl.transform.SetParent(pnf_tl.transform);
        Destroy(pnftl.GetComponent<MeshCollider>());
        
        GameObject pnf_tr = Instantiate(option, new Vector3(col6, row3, 0), Quaternion.identity);
        pnf_tr.name = "pnf_tr";
        GameObject pnftr = Instantiate(pnf, new Vector3(col6, row3, 0) + tr, Quaternion.identity);
        pnftr.transform.SetParent(pnf_tr.transform);
        Destroy(pnftr.GetComponent<MeshCollider>());
        
        GameObject pnf_bl = Instantiate(option, new Vector3(col6, row4, 0), Quaternion.identity);
        pnf_bl.name = "pnf_bl";
        GameObject pnfbl = Instantiate(pnf, new Vector3(col6, row4, 0) + bl, Quaternion.identity);
        pnfbl.transform.SetParent(pnf_bl.transform);
        Destroy(pnfbl.GetComponent<MeshCollider>());
        
        GameObject pnf_br = Instantiate(option, new Vector3(col6, row5, 0), Quaternion.identity);
        pnf_br.name = "pnf_br";
        GameObject pnfbr = Instantiate(pnf, new Vector3(col6, row5, 0) + br, Quaternion.identity);
        pnfbr.transform.SetParent(pnf_br.transform);
        Destroy(pnfbr.GetComponent<MeshCollider>());

        print("Initialization finished");
        
    }
    
    public void MoveBack(string name){

        if (GlobalControl.Instance.handOption == 0)
        {
            col1 = 0f;
            col2 = 0.075f;
            col3 = 0.15f;
            col4 = 0.225f;
            col5 = 0.3f;
            col6 = 0.375f;

            row1 = 0.15f;
            row2 = 0.075f;
            row3 = 0f;
            row4 = -0.075f;
            row5 = -0.15f;

        }
        else
        {
            col1 = 0f;
            col2 = -0.075f;
            col3 = -0.15f;
            col4 = -0.225f;
            col5 = -0.3f;
            col6 = -0.375f;

            row1 = 0.15f;
            row2 = 0.075f;
            row3 = 0f;
            row4 = -0.075f;
            row5 = -0.15f;
        }

        switch (name){
            
            case string n when name.Contains("df"):
                col = col1;
                break;
            case string n when name.Contains("dnf"):
                col = col2;
                break;
            case string n when name.Contains("sf"):
                col = col3;
                break;
            case string n when name.Contains("snf"):
                col = col4;
                break;
            case string n when name.Contains("pf"):
                col = col5;
                break;
            case string n when name.Contains("pnf"):
                col = col6;
                break;
            
        }
        
        switch(name){
            
            case string n when name.Contains("c"):
                row = row1;
                break;
            case string n when name.Contains("tl"):
                row = row2;
                break;
            case string n when name.Contains("tr"):
                row = row3;
                break;
            case string n when name.Contains("bl"):
                row = row4;
                break;
            case string n when name.Contains("br"):
                row = row5;
                break;
            
        }
        
        

        
    }

}

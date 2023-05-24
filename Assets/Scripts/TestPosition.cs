using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPosition : MonoBehaviour
{
    // float values for the options position and the relative shape position
    public float row1, row2, row3, row4, row5;
    public float col1, col2, col3, col4, col5, col6;
    public Vector3 c, tl, tr, bl, br;
    
    // get game objects set up
    public GameObject option, df, dnf, sf, snf, cf, cnf;
    private GameObject df_c, df_tl, df_tr, df_bl, df_br;
    private GameObject dnf_c, dnf_tl, dnf_tr, dnf_bl, dnf_br;
    private GameObject sf_c, sf_tl, sf_tr, sf_bl, sf_br;
    private GameObject snf_c, snf_tl, snf_tr, snf_bl, snf_br;
    private GameObject cf_c, cf_tl, cf_tr, cf_bl, cf_br;
    private GameObject cnf_c, cnf_tl, cnf_tr, cnf_bl, cnf_br;

    public void Start(){
        
        Initialize();
        
    }
    
    public void Initialize(){
        
        // assign values to the options position
        col1 = -22f;
        col2 = -11f;
        col3 = 0f;
        col4 = 11f;
        col5 = 22f;
        col6 = 33f;
        
        row1 = 22f;
        row2 = 11f;
        row3 = 0f;
        row4= -11f;
        row5= -22f;
        
        // relative shape position
        tl = new Vector3(-3f, 3f, -0.01f);
        tr = new Vector3(3f, 3f, -0.01f);
        bl = new Vector3(-3f, -3f, -0.01f);
        br = new Vector3(3f, -3f, -0.01f);
        
        // column 1: dot filled (df)
        df_c = Instantiate(option, new Vector3(col1, row1, 0), Quaternion.identity);
        GameObject dfc = Instantiate(df, new Vector3(col1, row1, 0), Quaternion.identity);
        dfc.transform.SetParent(df_c.transform);

        df_tl = Instantiate(option, new Vector3(col1, row2, 0), Quaternion.identity);
        GameObject dftl = Instantiate(df, new Vector3(col1, row2, 0) + tl, Quaternion.identity);
        dftl.transform.SetParent(df_tl.transform);
        
        df_tr = Instantiate(option, new Vector3(col1, row3, 0), Quaternion.identity);
        GameObject dftr = Instantiate(df, new Vector3(col1, row3, 0) + tr, Quaternion.identity);
        dftr.transform.SetParent(df_tr.transform);
        
        df_bl = Instantiate(option, new Vector3(col1, row4, 0), Quaternion.identity);
        GameObject dfbl = Instantiate(df, new Vector3(col1, row4, 0) + bl, Quaternion.identity);
        dfbl.transform.SetParent(df_bl.transform);
        
        df_br = Instantiate(option, new Vector3(col1, row5, 0), Quaternion.identity);
        GameObject dfbr = Instantiate(df, new Vector3(col1, row5, 0) + br, Quaternion.identity);
        dfbr.transform.SetParent(df_br.transform);
        
        // column 2: dot not filled (dnf)
        dnf_c = Instantiate(option, new Vector3(col2, row1, 0), Quaternion.identity);
        GameObject dnfc = Instantiate(dnf, new Vector3(col2, row1, 0), Quaternion.identity);
        dnfc.transform.SetParent(dnf_c.transform);
        
        dnf_tl = Instantiate(option, new Vector3(col2, row2, 0), Quaternion.identity);
        GameObject dnftl = Instantiate(dnf, new Vector3(col2, row2, 0) + tl, Quaternion.identity);
        dnftl.transform.SetParent(dnf_tl.transform);
        
        dnf_tr = Instantiate(option, new Vector3(col2, row3, 0), Quaternion.identity);
        GameObject dnftr = Instantiate(dnf, new Vector3(col2, row3, 0) + tr, Quaternion.identity);
        dnftr.transform.SetParent(dnf_tr.transform);
        
        dnf_bl = Instantiate(option, new Vector3(col2, row4, 0), Quaternion.identity);
        GameObject dnfbl = Instantiate(dnf, new Vector3(col2, row4, 0) + bl, Quaternion.identity);
        dnfbl.transform.SetParent(dnf_bl.transform);
        
        dnf_br = Instantiate(option, new Vector3(col2, row5, 0), Quaternion.identity);
        GameObject dnfbr = Instantiate(dnf, new Vector3(col2, row5, 0) + br, Quaternion.identity);
        dnfbr.transform.SetParent(dnf_br.transform);
        
        // column 3: square filled (sf)
        sf_c = Instantiate(option, new Vector3(col3, row1, 0), Quaternion.identity);
        GameObject sfc = Instantiate(sf, new Vector3(col3, row1, 0), Quaternion.identity);
        sfc.transform.SetParent(sf_c.transform);
        
        sf_tl = Instantiate(option, new Vector3(col3, row2, 0), Quaternion.identity);
        GameObject sftl = Instantiate(sf, new Vector3(col3, row2, 0) + tl, Quaternion.identity);
        sftl.transform.SetParent(sf_tl.transform);
        
        sf_tr = Instantiate(option, new Vector3(col3, row3, 0), Quaternion.identity);
        GameObject sftr = Instantiate(sf, new Vector3(col3, row3, 0) + tr, Quaternion.identity);
        sftr.transform.SetParent(sf_tr.transform);
        
        sf_bl = Instantiate(option, new Vector3(col3, row4, 0), Quaternion.identity);
        GameObject sfbl = Instantiate(sf, new Vector3(col3, row4, 0) + bl, Quaternion.identity);
        sfbl.transform.SetParent(sf_bl.transform);
        
        sf_br = Instantiate(option, new Vector3(col3, row5, 0), Quaternion.identity);
        GameObject sfbr = Instantiate(sf, new Vector3(col3, row5, 0) + br, Quaternion.identity);
        sfbr.transform.SetParent(sf_br.transform);
        
        // column 4: square not filled (snf)
        snf_c = Instantiate(option, new Vector3(col4, row1, 0), Quaternion.identity);
        GameObject snfc = Instantiate(snf, new Vector3(col4, row1, 0), Quaternion.identity);
        snfc.transform.SetParent(snf_c.transform);
        
        snf_tl = Instantiate(option, new Vector3(col4, row2, 0), Quaternion.identity);
        GameObject snftl = Instantiate(snf, new Vector3(col4, row2, 0) + tl, Quaternion.identity);
        snftl.transform.SetParent(snf_tl.transform);
        
        snf_tr = Instantiate(option, new Vector3(col4, row3, 0), Quaternion.identity);
        GameObject snftr = Instantiate(snf, new Vector3(col4, row3, 0) + tr, Quaternion.identity);
        snftr.transform.SetParent(snf_tr.transform);
        
        snf_bl = Instantiate(option, new Vector3(col4, row4, 0), Quaternion.identity);
        GameObject snfbl = Instantiate(snf, new Vector3(col4, row4, 0) + bl, Quaternion.identity);
        snfbl.transform.SetParent(snf_bl.transform);
        
        snf_br = Instantiate(option, new Vector3(col4, row5, 0), Quaternion.identity);
        GameObject snfbr = Instantiate(snf, new Vector3(col4, row5, 0) + br, Quaternion.identity);
        snfbr.transform.SetParent(snf_br.transform);
        
        // column 5: cross filled (cf)
        cf_c = Instantiate(option, new Vector3(col5, row1, 0), Quaternion.identity);
        GameObject cfc = Instantiate(cf, new Vector3(col5, row1, 0), Quaternion.identity);
        cfc.transform.SetParent(cf_c.transform);
        
        cf_tl = Instantiate(option, new Vector3(col5, row2, 0), Quaternion.identity);
        GameObject cftl = Instantiate(cf, new Vector3(col5, row2, 0) + tl, Quaternion.identity);
        cftl.transform.SetParent(cf_tl.transform);
        
        cf_tr = Instantiate(option, new Vector3(col5, row3, 0), Quaternion.identity);
        GameObject cftr = Instantiate(cf, new Vector3(col5, row3, 0) + tr, Quaternion.identity);
        cftr.transform.SetParent(cf_tr.transform);
        
        cf_bl = Instantiate(option, new Vector3(col5, row4, 0), Quaternion.identity);
        GameObject cfbl = Instantiate(cf, new Vector3(col5, row4, 0) + bl, Quaternion.identity);
        cfbl.transform.SetParent(cf_bl.transform);
        
        cf_br = Instantiate(option, new Vector3(col5, row5, 0), Quaternion.identity);
        GameObject cfbr = Instantiate(cf, new Vector3(col5, row5, 0) + br, Quaternion.identity);
        cfbr.transform.SetParent(cf_br.transform);
        
        // column 6: cross not filled (cnf)
        cnf_c = Instantiate(option, new Vector3(col6, row1, 0), Quaternion.identity);
        GameObject cnfc = Instantiate(cnf, new Vector3(col6, row1, 0), Quaternion.identity);
        cnfc.transform.SetParent(cnf_c.transform);
        
        cnf_tl = Instantiate(option, new Vector3(col6, row2, 0), Quaternion.identity);
        GameObject cnftl = Instantiate(cnf, new Vector3(col6, row2, 0) + tl, Quaternion.identity);
        cnftl.transform.SetParent(cnf_tl.transform);
        
        cnf_tr = Instantiate(option, new Vector3(col6, row3, 0), Quaternion.identity);
        GameObject cnftr = Instantiate(cnf, new Vector3(col6, row3, 0) + tr, Quaternion.identity);
        cnftr.transform.SetParent(cnf_tr.transform);
        
        cnf_bl = Instantiate(option, new Vector3(col6, row4, 0), Quaternion.identity);
        GameObject cnfbl = Instantiate(cnf, new Vector3(col6, row4, 0) + bl, Quaternion.identity);
        cnfbl.transform.SetParent(cnf_bl.transform);
        
        cnf_br = Instantiate(option, new Vector3(col6, row5, 0), Quaternion.identity);
        GameObject cnfbr = Instantiate(cnf, new Vector3(col6, row5, 0) + br, Quaternion.identity);
        cnfbr.transform.SetParent(cnf_br.transform);

        print("finished");
    }
}

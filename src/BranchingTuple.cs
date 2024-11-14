namespace TupleFest;

public abstract class BranchingTuple : CommonTuple
{
}

public class BranchingTuple<T1>(T1 item1) : BranchingTuple
{
    public T1 Item1 { get; set;} = item1;
    public override void Traverse(Action<object?> action) {
        action(Item1);
    }
}

public class BranchingTuple<T1, T2>(T1 item1, T2 item2) : BranchingTuple<T1>(item1) {
    public T2 Item2 { get; set; } = item2;

    public override void Traverse(Action<object?> action) {
        base.Traverse(action);
        action(Item2);
    }
}
public class BranchingTuple<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4) : BranchingTuple<T1, T2>(item1, item2) {
    public T3 Item3 { get; set; } = item3;

    public T4 Item4 { get; set; } = item4;

    public override void Traverse(Action<object?> action) {
        base.Traverse(action);
        action(Item3);
        action(Item4);
    }
}
public class BranchingTuple<T1, T2, T3, T4, T5, T6, T7, T8>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8) : BranchingTuple<T1, T2, T3, T4>(item1, item2, item3, item4) {
    public T5 Item5 { get; set; } = item5;

    public T6 Item6 { get; set; } = item6;

    public T7 Item7 { get; set; } = item7;

    public T8 Item8 { get; set; } = item8;

    public override void Traverse(Action<object?> action) {
        base.Traverse(action);
        action(Item5);
        action(Item6);
        action(Item7);
        action(Item8);
    }
}
public class BranchingTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12, T13 item13, T14 item14, T15 item15, T16 item16) : BranchingTuple<T1, T2, T3, T4, T5, T6, T7, T8>(item1, item2, item3, item4, item5, item6, item7, item8) {
    public T9 Item9 { get; set; } = item9;

    public T10 Item10 { get; set; } = item10;

    public T11 Item11 { get; set; } = item11;

    public T12 Item12 { get; set; } = item12;

    public T13 Item13 { get; set; } = item13;

    public T14 Item14 { get; set; } = item14;

    public T15 Item15 { get; set; } = item15;

    public T16 Item16 { get; set; } = item16;

    public override void Traverse(Action<object?> action) {
        base.Traverse(action);
        action(Item9);
        action(Item10);
        action(Item11);
        action(Item12);
        action(Item13);
        action(Item14);
        action(Item15);
        action(Item16);
    }
}

public class BranchingTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12, T13 item13, T14 item14, T15 item15, T16 item16, T17 item17) : BranchingTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, item13, item14, item15, item16) {
    public T17 Item17 { get; set; } = item17;

    public override void Traverse(Action<object?> action) {
        base.Traverse(action);
        action(Item17);
    }
}

public class BranchingTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12, T13 item13, T14 item14, T15 item15, T16 item16, T17 item17, T18 item18, T19 item19, T20 item20, T21 item21, T22 item22, T23 item23, T24 item24, T25 item25, T26 item26, T27 item27, T28 item28, T29 item29, T30 item30, T31 item31, T32 item32) : BranchingTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, item13, item14, item15, item16) {
    public T17 Item17 { get; set; } = item17;

    public T18 Item18 { get; set; } = item18;

    public T19 Item19 { get; set; } = item19;

    public T20 Item20 { get; set; } = item20;

    public T21 Item21 { get; set; } = item21;

    public T22 Item22 { get; set; } = item22;

    public T23 Item23 { get; set; } = item23;

    public T24 Item24 { get; set; } = item24;

    public T25 Item25 { get; set; } = item25;

    public T26 Item26 { get; set; } = item26;

    public T27 Item27 { get; set; } = item27;

    public T28 Item28 { get; set; } = item28;

    public T29 Item29 { get; set; } = item29;

    public T30 Item30 { get; set; } = item30;

    public T31 Item31 { get; set; } = item31;

    public T32 Item32 { get; set; } = item32;

    public override void Traverse(Action<object?> action) {
        base.Traverse(action);
        action(Item17);
        action(Item18);
        action(Item19);
        action(Item20);
        action(Item21);
        action(Item22);
        action(Item23);
        action(Item24);
        action(Item25);
        action(Item26);
        action(Item27);
        action(Item28);
        action(Item29);
        action(Item30);
        action(Item31);
        action(Item32);
    }
}
public class BranchingTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12, T13 item13, T14 item14, T15 item15, T16 item16, T17 item17, T18 item18, T19 item19, T20 item20, T21 item21, T22 item22, T23 item23, T24 item24, T25 item25, T26 item26, T27 item27, T28 item28, T29 item29, T30 item30, T31 item31, T32 item32, T33 item33, T34 item34, T35 item35, T36 item36, T37 item37, T38 item38, T39 item39, T40 item40, T41 item41, T42 item42, T43 item43, T44 item44, T45 item45, T46 item46, T47 item47, T48 item48, T49 item49, T50 item50, T51 item51, T52 item52, T53 item53, T54 item54, T55 item55, T56 item56, T57 item57, T58 item58, T59 item59, T60 item60, T61 item61, T62 item62, T63 item63, T64 item64) : BranchingTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32>(item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, item13, item14, item15, item16, item17, item18, item19, item20, item21, item22, item23, item24, item25, item26, item27, item28, item29, item30, item31, item32) {
    public T33 Item33 { get; set; } = item33;

    public T34 Item34 { get; set; } = item34;

    public T35 Item35 { get; set; } = item35;

    public T36 Item36 { get; set; } = item36;

    public T37 Item37 { get; set; } = item37;

    public T38 Item38 { get; set; } = item38;

    public T39 Item39 { get; set; } = item39;

    public T40 Item40 { get; set; } = item40;

    public T41 Item41 { get; set; } = item41;

    public T42 Item42 { get; set; } = item42;

    public T43 Item43 { get; set; } = item43;

    public T44 Item44 { get; set; } = item44;

    public T45 Item45 { get; set; } = item45;

    public T46 Item46 { get; set; } = item46;

    public T47 Item47 { get; set; } = item47;

    public T48 Item48 { get; set; } = item48;

    public T49 Item49 { get; set; } = item49;

    public T50 Item50 { get; set; } = item50;

    public T51 Item51 { get; set; } = item51;

    public T52 Item52 { get; set; } = item52;

    public T53 Item53 { get; set; } = item53;

    public T54 Item54 { get; set; } = item54;

    public T55 Item55 { get; set; } = item55;

    public T56 Item56 { get; set; } = item56;

    public T57 Item57 { get; set; } = item57;

    public T58 Item58 { get; set; } = item58;

    public T59 Item59 { get; set; } = item59;

    public T60 Item60 { get; set; } = item60;

    public T61 Item61 { get; set; } = item61;

    public T62 Item62 { get; set; } = item62;

    public T63 Item63 { get; set; } = item63;

    public T64 Item64 { get; set; } = item64;

    public override void Traverse(Action<object?> action) {
        base.Traverse(action);
        action(Item33);
        action(Item34);
        action(Item35);
        action(Item36);
        action(Item37);
        action(Item38);
        action(Item39);
        action(Item40);
        action(Item41);
        action(Item42);
        action(Item43);
        action(Item44);
        action(Item45);
        action(Item46);
        action(Item47);
        action(Item48);
        action(Item49);
        action(Item50);
        action(Item51);
        action(Item52);
        action(Item53);
        action(Item54);
        action(Item55);
        action(Item56);
        action(Item57);
        action(Item58);
        action(Item59);
        action(Item60);
        action(Item61);
        action(Item62);
        action(Item63);
        action(Item64);
    }
}
public class BranchingTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98, T99, T100, T101, T102, T103, T104, T105, T106, T107, T108, T109, T110, T111, T112, T113, T114, T115, T116, T117, T118, T119, T120, T121, T122, T123, T124, T125, T126, T127, T128>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12, T13 item13, T14 item14, T15 item15, T16 item16, T17 item17, T18 item18, T19 item19, T20 item20, T21 item21, T22 item22, T23 item23, T24 item24, T25 item25, T26 item26, T27 item27, T28 item28, T29 item29, T30 item30, T31 item31, T32 item32, T33 item33, T34 item34, T35 item35, T36 item36, T37 item37, T38 item38, T39 item39, T40 item40, T41 item41, T42 item42, T43 item43, T44 item44, T45 item45, T46 item46, T47 item47, T48 item48, T49 item49, T50 item50, T51 item51, T52 item52, T53 item53, T54 item54, T55 item55, T56 item56, T57 item57, T58 item58, T59 item59, T60 item60, T61 item61, T62 item62, T63 item63, T64 item64, T65 item65, T66 item66, T67 item67, T68 item68, T69 item69, T70 item70, T71 item71, T72 item72, T73 item73, T74 item74, T75 item75, T76 item76, T77 item77, T78 item78, T79 item79, T80 item80, T81 item81, T82 item82, T83 item83, T84 item84, T85 item85, T86 item86, T87 item87, T88 item88, T89 item89, T90 item90, T91 item91, T92 item92, T93 item93, T94 item94, T95 item95, T96 item96, T97 item97, T98 item98, T99 item99, T100 item100, T101 item101, T102 item102, T103 item103, T104 item104, T105 item105, T106 item106, T107 item107, T108 item108, T109 item109, T110 item110, T111 item111, T112 item112, T113 item113, T114 item114, T115 item115, T116 item116, T117 item117, T118 item118, T119 item119, T120 item120, T121 item121, T122 item122, T123 item123, T124 item124, T125 item125, T126 item126, T127 item127, T128 item128) : BranchingTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64>(item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, item13, item14, item15, item16, item17, item18, item19, item20, item21, item22, item23, item24, item25, item26, item27, item28, item29, item30, item31, item32, item33, item34, item35, item36, item37, item38, item39, item40, item41, item42, item43, item44, item45, item46, item47, item48, item49, item50, item51, item52, item53, item54, item55, item56, item57, item58, item59, item60, item61, item62, item63, item64) {
    public T65 Item65 { get; set; } = item65;

    public T66 Item66 { get; set; } = item66;

    public T67 Item67 { get; set; } = item67;

    public T68 Item68 { get; set; } = item68;

    public T69 Item69 { get; set; } = item69;

    public T70 Item70 { get; set; } = item70;

    public T71 Item71 { get; set; } = item71;

    public T72 Item72 { get; set; } = item72;

    public T73 Item73 { get; set; } = item73;

    public T74 Item74 { get; set; } = item74;

    public T75 Item75 { get; set; } = item75;

    public T76 Item76 { get; set; } = item76;

    public T77 Item77 { get; set; } = item77;

    public T78 Item78 { get; set; } = item78;

    public T79 Item79 { get; set; } = item79;

    public T80 Item80 { get; set; } = item80;

    public T81 Item81 { get; set; } = item81;

    public T82 Item82 { get; set; } = item82;

    public T83 Item83 { get; set; } = item83;

    public T84 Item84 { get; set; } = item84;

    public T85 Item85 { get; set; } = item85;

    public T86 Item86 { get; set; } = item86;

    public T87 Item87 { get; set; } = item87;

    public T88 Item88 { get; set; } = item88;

    public T89 Item89 { get; set; } = item89;

    public T90 Item90 { get; set; } = item90;

    public T91 Item91 { get; set; } = item91;

    public T92 Item92 { get; set; } = item92;

    public T93 Item93 { get; set; } = item93;

    public T94 Item94 { get; set; } = item94;

    public T95 Item95 { get; set; } = item95;

    public T96 Item96 { get; set; } = item96;

    public T97 Item97 { get; set; } = item97;

    public T98 Item98 { get; set; } = item98;

    public T99 Item99 { get; set; } = item99;

    public T100 Item100 { get; set; } = item100;

    public T101 Item101 { get; set; } = item101;

    public T102 Item102 { get; set; } = item102;

    public T103 Item103 { get; set; } = item103;

    public T104 Item104 { get; set; } = item104;

    public T105 Item105 { get; set; } = item105;

    public T106 Item106 { get; set; } = item106;

    public T107 Item107 { get; set; } = item107;

    public T108 Item108 { get; set; } = item108;

    public T109 Item109 { get; set; } = item109;

    public T110 Item110 { get; set; } = item110;

    public T111 Item111 { get; set; } = item111;

    public T112 Item112 { get; set; } = item112;

    public T113 Item113 { get; set; } = item113;

    public T114 Item114 { get; set; } = item114;

    public T115 Item115 { get; set; } = item115;

    public T116 Item116 { get; set; } = item116;

    public T117 Item117 { get; set; } = item117;

    public T118 Item118 { get; set; } = item118;

    public T119 Item119 { get; set; } = item119;

    public T120 Item120 { get; set; } = item120;

    public T121 Item121 { get; set; } = item121;

    public T122 Item122 { get; set; } = item122;

    public T123 Item123 { get; set; } = item123;

    public T124 Item124 { get; set; } = item124;

    public T125 Item125 { get; set; } = item125;

    public T126 Item126 { get; set; } = item126;

    public T127 Item127 { get; set; } = item127;

    public T128 Item128 { get; set; } = item128;

    public override void Traverse(Action<object?> action) {
        base.Traverse(action);
        action(Item65);
        action(Item66);
        action(Item67);
        action(Item68);
        action(Item69);
        action(Item70);
        action(Item71);
        action(Item72);
        action(Item73);
        action(Item74);
        action(Item75);
        action(Item76);
        action(Item77);
        action(Item78);
        action(Item79);
        action(Item80);
        action(Item81);
        action(Item82);
        action(Item83);
        action(Item84);
        action(Item85);
        action(Item86);
        action(Item87);
        action(Item88);
        action(Item89);
        action(Item90);
        action(Item91);
        action(Item92);
        action(Item93);
        action(Item94);
        action(Item95);
        action(Item96);
        action(Item97);
        action(Item98);
        action(Item99);
        action(Item100);
        action(Item101);
        action(Item102);
        action(Item103);
        action(Item104);
        action(Item105);
        action(Item106);
        action(Item107);
        action(Item108);
        action(Item109);
        action(Item110);
        action(Item111);
        action(Item112);
        action(Item113);
        action(Item114);
        action(Item115);
        action(Item116);
        action(Item117);
        action(Item118);
        action(Item119);
        action(Item120);
        action(Item121);
        action(Item122);
        action(Item123);
        action(Item124);
        action(Item125);
        action(Item126);
        action(Item127);
        action(Item128);
    }
}
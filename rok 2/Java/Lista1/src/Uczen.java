public class Uczen {
    public static int numerKursu;
    public final int rok;
    private String imie;
    private int ocena;
    private String ulubionyKolor;

    public Uczen() {
        rok = 2001;
    }

    public Uczen(String imie) {
        this();
        setImie(imie);
    }

    public Uczen(String imie, int ocena) {
        this();
        setImie(imie);
        setOcena(ocena);
    }

    public Uczen(String imie, int ocena, String ulubionyKolor, int rok) {
        this();
        setImie(imie);
        setOcena(ocena);
        setUlubionyKolor(ulubionyKolor);
    }

    public String getImie() {
        return imie;
    }

    public void setImie(String imie) {
        this.imie = imie;
    }

    public int getOcena() {
        return this.ocena;
    }

    public void setOcena(int ocena) {
        this.ocena = ocena;
    }

    public String getUlubionyKolor() {
        return this.ulubionyKolor;
    }

    public void setUlubionyKolor(String ulubionyKolor) {
        this.ulubionyKolor = ulubionyKolor;
    }

    public void printAllProperty() {
        System.out.println(getImie());
        System.out.println(Uczen.numerKursu);
        System.out.println(rok);
        System.out.println(getOcena());
        System.out.println(getUlubionyKolor());
    }
}

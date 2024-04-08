package pl.opole.uni.lista2.model;

import jakarta.persistence.*;

import java.util.List;
import java.util.Objects;

@Entity
public class Uzytkownik {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer uzytkownikID;
    private String imie;
    private String nazwisko;
    private String pesel;
    private String stanowisko;
    @ManyToOne
    @JoinColumn(name = "dzial")
    private Dzial dzial;
    @ManyToMany
    @JoinTable(name="uzytkownik_urzadzenia", joinColumns = {@JoinColumn(name = "urzadzenieID")},inverseJoinColumns = {@JoinColumn(name = "uzytkownikID")})
    private List<Urzadzenie> urzadzenia;

    public Integer getUzytkownikID() {
        return uzytkownikID;
    }

    public void setUzytkownikID(Integer uzytkownikID) {
        this.uzytkownikID = uzytkownikID;
    }

    public String getImie() {
        return imie;
    }

    public void setImie(String imie) {
        this.imie = imie;
    }

    public String getNazwisko() {
        return nazwisko;
    }

    public void setNazwisko(String nazwisko) {
        this.nazwisko = nazwisko;
    }

    public String getPesel() {
        return pesel;
    }

    public void setPesel(String pesel) {
        this.pesel = pesel;
    }

    public String getStanowisko() {
        return stanowisko;
    }

    public void setStanowisko(String stanowisko) {
        this.stanowisko = stanowisko;
    }

    public Dzial getDzial() {
        return dzial;
    }

    public void setDzial(Dzial dzial) {
        this.dzial = dzial;
    }

    public List<Urzadzenie> getUrzadzenia() {
        return urzadzenia;
    }

    public void setUrzadzenia(List<Urzadzenie> urzadzenia) {
        this.urzadzenia = urzadzenia;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Uzytkownik that = (Uzytkownik) o;
        return Objects.equals(uzytkownikID, that.uzytkownikID);
    }

    @Override
    public int hashCode() {
        return Objects.hash(uzytkownikID);
    }
}
